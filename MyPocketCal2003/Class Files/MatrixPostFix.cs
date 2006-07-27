using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyPocketCal2003
{
    class MatrixPostFix
    {
        private static Hashtable ht; // hashtable of the precedences
		private static string goodWord; // matches any number
		private static string goodChr; // chars accepted in the infix expression
		
		public MatrixPostFix() 
		{
			// configure precedences
			ht=new Hashtable();
			ht.Add("(",9);
			ht.Add(")",9);
			ht.Add("^",7);
			ht.Add("*",5);
			ht.Add("/",5);
			ht.Add("%",5);
			ht.Add("+",3);
			ht.Add("-",3);
			
			// configure good number
			goodWord = @"\w+";
			
			// configure good chars
			goodChr=" ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz+-/*()";
		}
		
		
		public string Convert(string infix) 
        {
			try 
			{
				CheckAndFormat(ref infix);	
				
				StringBuilder rpn=new StringBuilder(); // rpn output string
				Stack st=new Stack(); // stack used to calculate

				string[] token=infix.Split(' ');
				
				for (int i=0; i<token.Length; i++) 
				{
					token[i]=token[i].Trim();
					if (IsWord(token[i])) 
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
								if (st.Count==0 || st.Peek().ToString()=="(" || HasPrecedence(token[i],st.Peek().ToString())) 
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
				return pex.Message;				
			} 
			catch (Exception ex) 
			{
				return ex.Message;
			}			
		}
		
		public bool IsWord(string n) 
		{
			return Regex.IsMatch(n,goodWord);
		}
		
		private void CheckAndFormat(ref string infix) 
		{
			// I replace eventually . [ and {
			infix=Regex.Replace(infix, @"\."     ,  @",");
			infix=Regex.Replace(infix, @"\[|\{"  ,  @"(");
			infix=Regex.Replace(infix, @"\]|\}"  ,  @")");
			
			// check for good chars
			for (int i=0; i<infix.Length; i++) 
			{
				if (goodChr.IndexOf(""+infix[i])==-1) 
				{
					throw new PostfixException(infix[i]+" is not an allowed char.");
				}
			}			
			
			// check for unbalanced or bad placed brackets
			MatchCollection mc1=Regex.Matches(infix, @"\(");
			MatchCollection mc2=Regex.Matches(infix, @"\)");
			
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
			
			for (int i=goodChr.IndexOf("+"); i<goodChr.Length; i++) 
			{
				infix=infix.Replace(""+goodChr[i] , " "+goodChr[i]+" ");
			}
			
			// I don't want consecutive spaces to be present since I have to split the string
			infix=Regex.Replace(infix,@"\s{2,}"," ");  
			infix=infix.Trim();
		}
		
		private bool HasPrecedence(string a, string b) 
		{
			return ((int)ht[a]>(int)ht[b]);
		}

        public Matrix Solve(string p, Hashtable dataMap)
        {
            Hashtable tempStorage = new Hashtable();

            try
            {
                Stack st = new Stack();
                
                String leftMatrixName;
                String rightMatrixName;

                string[] tok = p.Split(' ');
                for (int i = 0; i < tok.Length; i++)
                {
                    tok[i] = tok[i].Trim();
                    if (IsWord(tok[i])) 
                    {
                        st.Push(tok[i]);
                    }
                    else
                    {
                        rightMatrixName = st.Pop().ToString();
                        leftMatrixName = st.Pop().ToString();
                        Matrix result = null;
                        Matrix right = null;
                        Matrix left = null;

                        //if the Matrix being popped was a resultant it would be found in temporary Hashtable
                        if (tempStorage.Contains(rightMatrixName))
                            right = (Matrix)tempStorage[rightMatrixName];
                        else
                            right = (Matrix)dataMap[rightMatrixName];

                        if (tempStorage.Contains(leftMatrixName))
                            left = (Matrix)tempStorage[leftMatrixName];
                        else
                            left = (Matrix)dataMap[leftMatrixName];

                        switch (tok[i])
                        {
                            case "+":
                                result = left.add(left, right);
                                break;
                            case "-":
                                result = left.subtract(left, right);
                                break;
                            case "*":
                                result = left.multiply(left, right);
                                break;
                            default:
                                break;
                        }
                        //the resultant of A+B will be stored in a temporary hashtable
                        if(!tempStorage.Contains(result.getName()))
                            tempStorage.Add(result.getName(), result);

                        st.Push(result.getName());
                    }
                }
                //return the resultant Matrix
                return (Matrix)tempStorage[st.Pop().ToString()];
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                MessageBox.Show(e.StackTrace);
            }
            return null;
        }
	}

	public class PostfixException : System.Exception 
	{
		public PostfixException(string message) : base(message)
		{
		
		}
	}
}
