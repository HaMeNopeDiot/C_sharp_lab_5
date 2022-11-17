using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_sharp_lab_5
{
    public class String_text_changer
    {

		public String_text_changer()
		{
		}

		public string give_result(string file_text, string word)
        {
            string file_result = "";
            if(!check_is_word(word))
            {
                return file_result;
            }
            else
            {
                string[] strokes = file_text.Split(new char[] { '\n' });
                for(int i = 0; i < strokes.Length; i++)
                {
                    if(strokes[i].Contains(word))
                    {
                        int start = strokes[i].IndexOf(word);
                        //(start != 0 && strokes[i][start - 1] == ' ') || (start + word.Length + 1 < strokes[i].Length && strokes[i][start + word.Length + 1] == ' ')
                        bool flag = true;
                        if (start > 0 && strokes[i][start - 1] != ' ')
                            flag = false;
                        if (strokes[i].Length > start + word.Length + 1 && (strokes[i][start + word.Length + 1] != ' '))
                            flag = false;
                        if(flag)
                            file_result += strokes[i] + '\n';
                    }
                }
                return file_result;
            }
            

        }

        public string give_result_non_string(string file_text, string word)
        {
            string file_result = "";
            if (!check_is_word(word))
            {
                return file_result;
            }
            else
            {
                bool flag = false;
                string text_stroke = "";
                for(int i =0;i <= file_text.Length;i++)
                {
                    if(i == file_text.Length || file_text[i] == '\n')
                    {
                        flag = is_word_in_stroke(text_stroke, word);
                        if(flag)
                        {
                            file_result += text_stroke + "\n";
                        }
                        flag = false;
                        text_stroke = "";
                    }
                    else
                    {
                        text_stroke += file_text[i];
                    }
                }



                return file_result;
            }
        }

        public bool is_word_in_stroke(string stroke, string word)
        {
            for(int i = 0; i <= stroke.Length - word.Length; i++)
            {
                bool cond = true;
                int j;
                for (j = 0; j<word.Length && cond;j++)
                {
                    if (word[j] != stroke[i + j])
                        cond = false;
                }
                if(cond && stroke.Length > i + j + 1 && stroke[i + j + 1] != ' ')
                    cond = false;
                if (cond && i > 0 && (stroke[i - 1] != ' '))
                    cond = false;

                if (cond)
                    return true;

            }
            return false;
        }

		public bool check_is_word(string word)
        {
            int i = 0;
            while(word.Length > i)
            {
                if (!is_symbol(word[i]))
                    return false;
                i++;
            }
            return true;
        }

        public bool is_symbol(char symbol)
        {
            if (symbol == ' ' || symbol == '\n' || symbol == '\t')
                return false;
            else
                return true;
        }
    }
}
