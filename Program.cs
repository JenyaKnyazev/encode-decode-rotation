using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication29
{
    class Program
    {
        static string encode(int key, string text) {
            string res = text;
            for (int i = 0; i < key; i++) {
                List<int> pos = new List<int>();
                res = erase_space_save_indexes(res, pos);
                for (int r = 0; r < key; r++) 
                    res = shift_right(res);
                res = add_spaces(res, pos);
                string[] splited = res.Split(' ');
                res = "";
                for(int r=0;r<splited.Length;r++){
                    if (splited[r].Length > 1)
                        for (int j = 0; j < key % splited[r].Length; j++)
                            splited[r] = shift_right(splited[r]);
                    res += splited[r];
                }
                res = add_spaces(res, pos);
            }
            return res;
        }
        static string decode(int key, string text) {
            string res = text;
            for (int i = 0; i < key; i++) {
                List<int> pos = new List<int>();
                erase_space_save_indexes(res, pos);
                string[] splited = res.Split(' ');
                res="";
                for (int r = 0; r < splited.Length; r++) {
                    if(splited[r].Length>1)
                        for (int j = 0; j < key % splited[r].Length; j++)
                            splited[r] = shift_left(splited[r]);
                    res += splited[r];
                }
                for (int r = 0; r < key; r++)
                    res = shift_left(res);
                res = add_spaces(res, pos);
            }
            return res;
        }
        static void run() {
            int i;
            do{
                Console.WriteLine("encode 1\ndecode 2\nexit 3");
                i = int.Parse(Console.ReadLine());
                int key=0;
                string text="";
                if (i == 1 || i == 2) {
                    Console.WriteLine("enter key");
                    key = int.Parse(Console.ReadLine());
                    Console.WriteLine("enter text");
                    text=Console.ReadLine();
                }
                switch (i) {
                    case 1:
                        Console.WriteLine("\n" + encode(key, text));
                        break;
                    case 2:
                        Console.WriteLine("\n" + decode(key, text));
                        break;
                        
                }
            } while (i != 3);
        }
        static string shift_right(string text) {
            string res = "";
            for (int i = 0; i < text.Length - 1; i++)
                res += text[i];
            if (text.Length > 0)
                res = text[text.Length - 1] + res;
            return res;
        }
        static string shift_left(string text) {
            string res = "";
            for (int i = 1; i < text.Length ; i++)
                res += text[i];
            if (text.Length > 0)
                res +=text[0];
            return res;
        }
        static string erase_space_save_indexes(string s,List<int>save) {
            save.Clear();
            string res="";
            for (int i = 0; i < s.Length;i++ ){
                if (s[i] != ' ')
                    res += s[i];
                else
                    save.Add(i);
            }
            return res;
        }
        static string add_spaces(string s, List<int> indexes) {
            int index = 0;
            string res = "";
            for (int i = 0; i < s.Length || index < indexes.Count; ) {
                if (index < indexes.Count && i + index == indexes[index]) {
                    res += " ";
                    index++;
                }
                else if (i < s.Length) {
                    res += s[i];
                    i++;
                }
            }
            return res;
        }
        static void Main(string[] args)
        {
            run();
            Console.ReadLine();
        }
    }
}
