using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDesignPattern.Builders.ComputerBuilder
{
    public class ComputerSystem
    {
        public string RAM { get; set; }
        public string HardDrive { get; set; }
        public string GraphicsCard { get; set; }
        public string Mouse { get; set; }
        public string Keyborad { get; set; }
        public string Monitor { get; set; }
        public ComputerSystem()
        {

        }
        //public string Builder()
        //{
        //    StringBuilder st = new StringBuilder();
        //    st.Append(string.Format("RAM: {0}", RAM));
        //    st.Append(string.Format("Hard Drive: {0}", HardDrive));
        //    st.Append(string.Format("Graphics Card: {0}", GraphicsCard));
        //    return st.ToString();

        //}
    }
}
