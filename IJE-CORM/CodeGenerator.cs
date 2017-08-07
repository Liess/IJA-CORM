using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IJE
{
    class CodeGenerator
    {

        DBConnect dbConnect = new DBConnect();
        public string generateCodeParent(string forWhatTbl, string firstColumn,string pat)
        {
            int count;
            string genCode;
            string[] columns = { "count(*)" };
            List<object>[] rs = new List<object>[1];
            rs = dbConnect.Select("select count(*) from " + forWhatTbl + ";", columns);

            count = int.Parse(rs[0].ElementAt(0).ToString());
            if (count == 0)
            {
                string pattern = pat;
                if (pattern.Equals(""))
                {
                    genCode = count.ToString();
                }
                else
                {
                    genCode = pattern + count.ToString();
                }
            }
            else
            {
                //getting the prefix
                columns[0] = firstColumn;
                rs = dbConnect.Select("select " + firstColumn + " from " + forWhatTbl + " LIMIT 1;", columns);

                genCode = rs[0].ElementAt(0).ToString();
                for (int i = genCode.Length - 1; i >= 0; i--)
                {
                    double d;
                    bool canConvert = double.TryParse(genCode[i].ToString(), out d);
                    if (!canConvert)
                    {
                        genCode = genCode.Remove(i + 1);
                        break;
                    }
                }
                genCode += count.ToString();
            }

            return genCode;
        }


        public string generateCodeChild(string forWhatTbl, string firstColumn, string prefix, string pat)
        {
            int count;
            string genCode;
            string[] columns = { "count(*)" };
            List<object>[] rs = new List<object>[1];
            rs = dbConnect.Select("select count(*) from " + forWhatTbl + " where " + firstColumn + " LIKE '" + prefix +"-"+ pat + "%';", columns);

            count = int.Parse(rs[0].ElementAt(0).ToString());
            if (count == 0)
            {
                string pattern = pat;
                if (pattern.Equals(""))
                {
                    genCode = prefix + "-" + count.ToString();
                }
                else
                {
                    genCode = prefix + "-" + pattern + count.ToString();
                }

            }
            else
            {
                //getting the prefix
                columns[0] = firstColumn;
                rs = dbConnect.Select("select " + firstColumn + " from " + forWhatTbl + " where " + firstColumn + " LIKE '" + prefix + "%' LIMIT 1;", columns);

                genCode = rs[0].ElementAt(0).ToString();
                for (int i = genCode.Length - 1; i >= 0; i--)
                {
                    double d;
                    bool canConvert = double.TryParse(genCode[i].ToString(), out d);
                    if (!canConvert)
                    {
                        genCode = genCode.Remove(i + 1);
                        break;
                    }
                }
                genCode += count.ToString();
            }

            return genCode;
        }
    }
}
