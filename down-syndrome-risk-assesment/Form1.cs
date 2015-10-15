using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace down_syndrome_risk_assesment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            legBoneBox.SelectedItem = "Short femur";
            echogenicFocusList.SelectedItem = "Not Assessed";
            ventriculomegalyList.SelectedItem = "Not Assessed";
            echogenicBowelList.SelectedItem = "Not Assessed";
            hydronephrosisList.SelectedItem = "Not Assessed";
            legBoneList.SelectedItem = "Not Assessed";
            nasalBoneList.SelectedItem = "Not Assessed";
            bpdList.SelectedItem = "Not Assessed";
            nuchalFoldList.SelectedItem = "Not Assessed";
        }
    }
}
