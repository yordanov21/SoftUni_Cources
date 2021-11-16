namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            char One_Left = '(';
            char One_Rigth = ')';
            char Two_Left = '{';
            char Two_Right = '}';
            char Three_Left = '[';
            char Three_Right = ']';


            bool isBalanse = false;
            int one = 0;
            int two = 0;
            int three = 0;

            for (int i = 0; i < parentheses.Length; i++)
            {
                
     
                if (parentheses[i] == One_Left)
                {
                    one++;
                }
                else if (parentheses[i] == Two_Left)
                {
                    two++;
                }
                else if (parentheses[i] == Three_Left)
                {
                    three++;
                }

                else if (parentheses[i] == One_Rigth)
                {
                    one--;
                }
                else if (parentheses[i] == Two_Right)
                {
                    two--;
                }
                else if (parentheses[i] == Three_Right)
                {
                    three--;
                }


                
            }


            if (one == 0 && two == 0 && three == 0)
            {
                isBalanse = true;
            }
            

            return isBalanse;
        }
    }
}
