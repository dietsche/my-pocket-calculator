using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Windows.Forms;

namespace MyPocketCal2003
{
    class BasicPostFix
    {
        private static Hashtable ht; // hashtable of the precedences
        private string doubleNum;
		private string goodComplex1; // matches any number
        private string goodComplex2;
        //private string goodNum3;
        private static string goodChr; // chars accepted in the infix expression
		
		public BasicPostFix() 
        {
			// configure precedences
			ht=new Hashtable();
			ht.Add("(",9);
			ht.Add(")",9);
			ht.Add("x",5);
			ht.Add("/",5);
			ht.Add("%",5);
			ht.Add("+",3);
			ht.Add("-",3);
			
			// configure good number
			//doubleNum = @"^-?\d+(\.\d+)?([E][+-ab]\d+)?$"; //e.g. 20.2 or 20.22E+10 etc
            //goodNum2 = @"^[b]?\d+[a-b]{1}\d+[i]$"; //e.g. 2a2i or b2a2i
            //goodNum3 = @"^[b]?\d+(\.\d+)[a-b]{1}\d+(\.\d+)[i]$";

            //e.g. 20.2 or 20.22E+10 etc
            doubleNum = @"^[-b]?\d+(\.\d+)?([E][+-ab]\d+)?$";
            //e.g. 2+2i
            goodComplex1 = @"^[b]?\d+(\.\d+)?([E][ab]\d+)?[a-b]{1}\d+(\.\d+)?([E][ab]\d+)?[i]$";
            //e.g. 2+i or 2-i or 2.2-i
            goodComplex2 = @"^[b]?\d+(\.\d+)?([E][ab]\d+)?[a-b]{1}\d*[i]$";
            
			// allowable characters
            goodChr = " abEi0123456789.+-/x()";
		}


		public string Convert(string infix) 
        {
			try 
            {
				CheckAndFormat(ref infix);	
				
				StringBuilder rpn = new StringBuilder(); // rpn output string
				Stack st = new Stack(); // stack used to calculate

				string[] token=infix.Split(' ');
				
				for (int i=0; i<token.Length; i++) 
                {
					token[i]=token[i].Trim();
					if (IsNum(token[i])) 
                    {
						rpn.Append(token[i]+" ");
					} 
                    else 
                    {
						switch (token[i]) 
                        {
							case "(":
								st.Push(token[i]);
								break;
							case ")":
								while (true) 
                                {
									if (st.Peek().ToString()!="(") 
                                    {
										rpn.Append(st.Pop()+" ");
									} 
                                    else 
                                    {
										st.Pop();
										break;
									}
								}								
								break;
							default :
								if (st.Count==0 || st.Peek().ToString()=="(" || HasPrecedence(token[i], st.Peek().ToString())) 
                                {
									st.Push(token[i]);
								} 
                                else 
                                {
									rpn.Append(st.Pop()+" ");
									i--;
								}
								break;
						}
					}
				}

				while (st.Count!=0) 
                {
					rpn.Append(st.Pop()+" ");
				}
				return rpn.ToString().Trim();
			} 
            catch (PostfixException pex) 
            {
                throw pex;				
			} 
            catch (Exception ex) 
            {
                //MessageBox.Show(ex.StackTrace);
                throw ex;
			}			
		}

		private bool IsNum(string n) 
        {            
            return (Regex.IsMatch(n, doubleNum) || Regex.IsMatch(n, goodComplex1) || Regex.IsMatch(n, goodComplex2));
		}

		private void CheckAndFormat(ref string infix) 
        {
			// I replace eventually . [ and {
			infix=Regex.Replace(infix, @"\[|\{", @"(");
			infix=Regex.Replace(infix, @"\]|\}", @")");

			// check for good chars
			for (int i=0; i<infix.Length; i++) 
            {
				if (goodChr.IndexOf(""+infix[i])==-1) 
                {
					throw new PostfixException(infix[i]+" is not an allowed char.");
				}
			}			

			// check for unbalanced or bad placed brackets
			MatchCollection mc1=Regex.Matches(infix,@"\(");
			MatchCollection mc2=Regex.Matches(infix,@"\)");

			if (mc1.Count!=mc2.Count) 
            {
				throw new PostfixException("Unbalanced brackets");
			}

			for (int i=0; i<mc1.Count; i++) 
            {
				if (mc1[i].Index>mc2[i].Index) 
                {
					throw new PostfixException("Bad placed brackets");
				}
			}

			// all right, the infix string seems to be ok
			// if expression starts like -12... or +12... I add a 0
			// 0-12... or 0+12...
			if (infix[0]=='-' || infix[0]=='+') 
            {
				infix="0"+infix;
			}

            infix = infix.Replace("E+", "c");
            infix = infix.Replace("E-", "d");

			for (int i=goodChr.IndexOf("+"); i<goodChr.Length; i++) 
            {
				infix=infix.Replace(""+goodChr[i]," "+goodChr[i]+" ");
			}

            infix = infix.Replace("c", "E+");
            infix = infix.Replace("d", "E-");

			// I don't want consecutive spaces to be present since I have to split the string
			infix=Regex.Replace(infix,@"\s{2,}"," ");  
			infix=infix.Trim();
		}

		private bool HasPrecedence(string a, string b) 
        {
			return ((int)ht[a]>(int)ht[b]);
		}
        public string solveRPN(string p)
        {
            p = Regex.Replace(p, @",", @" ");
            return this.Solve(p);
        }
        public String Solve(string p)
        {
            try
            {
                Stack st = new Stack();
                String right = "";
                String left = "";
                ComplexNumber result = null;
                string[] tok = p.Split(' ');
                for (int i = 0; i < tok.Length; i++)
                {
                    tok[i] = tok[i].Trim();
                    if (IsNum(tok[i]))
                    {
                        st.Push(tok[i]);
                    }
                    else
                    {
                        right = st.Pop().ToString();
                        left = st.Pop().ToString();
                        //return the Complex representation of the complex number in string form
                        ComplexNumber complexRight = new ComplexNumber(right);
                        ComplexNumber complexLeft = new ComplexNumber(left);
                        switch (tok[i])
                        {
                            case "+": //addition
                                result = complexLeft + complexRight;
                                break;
                            case "-": //subtraction
                                result = complexLeft - complexRight;
                                break;
                            case "x": //multiplication
                                result = complexLeft * complexRight;
                                break;
                            case "/": //division
                                result = complexLeft / complexRight;
                                break;
                            default:
                                break;
                        }
                        st.Push(result.ToString());
                    }
                }
                //return the result
                ComplexNumber answer = new ComplexNumber(st.Pop().ToString());
                return answer.toMathString();
            }
            catch
            {
                //MessageBox.Show(ex.StackTrace);
                throw new Exception("Error");
            }
        }
	}
}
