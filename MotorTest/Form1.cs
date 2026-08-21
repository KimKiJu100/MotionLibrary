using ClassLibrary1.Motions._05.MotionState.Logic.DataTypes;
using ClassLibrary1.Motions._05.MotionState.Logic.Factorys;
using ClassLibrary1.Motions._98.MotorAxes;
using ClassLibrary1.Motions._98.MotorAxes.Factorys.Params;
using ClassLibrary1.Motions._05.MotionState.Logic.DataTypes.Base;
using ClassLibrary1.Motions._98.MotorAxes.Factorys.Params.Base;
using ClassLibrary1.Motions._98.MotorControls;
using ClassLibrary1.Motions._99.MotionContext;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MotorTest
{
    public partial class Form1 : Form
    {
        private IServiceProvider _serviceProvider;

        private MotionContext _context;

        private List<Label> Mechanical_LabelCollection;
        private List<Label> MotionEnd_LabelCollection ;
        private List<Label> MotionDrive_LabelCollection;
        private List<TextBox> MotionAxis_textBoxCollection;
        private CancellationTokenSource cts;

        public Form1()
        {
            InitializeComponent();
        }
        public Form1(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            Lazyinit();
            _serviceProvider = serviceProvider;
            _context = _serviceProvider.GetRequiredService<MotionContext>();

            var _ = new MotionAjinControl();
            var __ = new MotionAxisPartFactory();

            var ____ = __.CreateAxis(new AJINAxisParam() { DeviceName = "AJIN_Control1", iAxisHandler = 0 });
            var _____ = __.CreateAxis(new AJINAxisParam() { DeviceName = "AJIN_Control1", iAxisHandler = 1 });
            var ______ = __.CreateAxis(new AJINAxisParam() { DeviceName = "AJIN_Control1", iAxisHandler = 2 });

            _.AddAxis(GetDeviceKey(____.DeviceName, ____.AxisNumber), ____);
            _.AddAxis(GetDeviceKey(_____.DeviceName, _____.AxisNumber), _____);
            _.AddAxis(GetDeviceKey(______.DeviceName, ______.AxisNumber), ______);

            _context.AddControl("Test", _);
        }

        private void Lazyinit()
        {
            Mechanical_LabelCollection = new List<Label>() { lbl_Mechanical_00, lbl_Mechanical_01, lbl_Mechanical_02, lbl_Mechanical_03,
            lbl_Mechanical_04, lbl_Mechanical_05, lbl_Mechanical_06, lbl_Mechanical_07,
            lbl_Mechanical_08, lbl_Mechanical_09, lbl_Mechanical_10, lbl_Mechanical_11,
            lbl_Mechanical_12, lbl_Mechanical_13, lbl_Mechanical_14, lbl_Mechanical_15 };


            MotionEnd_LabelCollection = new List<Label>() { lbl_MotionEnd_00, lbl_MotionEnd_01, lbl_MotionEnd_02, lbl_MotionEnd_03,
            lbl_MotionEnd_04, lbl_MotionEnd_05, lbl_MotionEnd_06, lbl_MotionEnd_07,
            lbl_MotionEnd_08, lbl_MotionEnd_09, lbl_MotionEnd_10, lbl_MotionEnd_11,
            lbl_MotionEnd_12, lbl_MotionEnd_13, lbl_MotionEnd_14, lbl_MotionEnd_15 };


            MotionDrive_LabelCollection = new List<Label>() { lbl_Drive_00, lbl_Drive_01, lbl_Drive_02, lbl_Drive_03,
            lbl_Drive_04, lbl_Drive_05, lbl_Drive_06, lbl_Drive_07,
            lbl_Drive_08, lbl_Drive_09, lbl_Drive_10, lbl_Drive_11,
            lbl_Drive_12, lbl_Drive_13, lbl_Drive_14, lbl_Drive_15 };

            MotionAxis_textBoxCollection = new List<TextBox>()
            {
                txtbox_1,txtbox_2,txtbox_3,
            };
        }

        private string GetDeviceKey(string Device, int HandlerNumber)
        {
            return $"{Device}" + '_' +  $"{HandlerNumber}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var control = _context.GetMotionControls("Test");
            control.ConnectionMotionDevice();
        }

        private void TestMonitoring(CancellationToken token)
        {
            var key = GetDeviceKey("AJIN_Control1", 0);
            var control = _context.GetMotionControls("Test");

            while (!token.IsCancellationRequested)
            {
                var state = control[key]?.GetState(StateMode.AJIN_DriveMechanical);
                var state1 = control[key]?.GetState(StateMode.AJIN_ENDLogic);
                var state2 = control[key]?.GetState(StateMode.AJIN_DriveMode);
                var state3 = control[key]?.GetState(StateMode.AJIN_AxisMoveInfor);

                var v = state.Cast<MotionStatus>().Values.ToList();
                var v1 = state1.Cast<MotionStatus>().Values.ToList();
                var v2 = state2.Cast<MotionStatus>().Values.ToList();
                var v3 = state3.Cast<MotionStatus<double>>().Values.ToList();

                Invoke((Action)(() =>
                {
                    for (int i = 0; i < v.Count; i++)
                    {
                        Mechanical_LabelCollection[i].BackColor =
                            v[i] ? Color.LightGreen : Color.White;
                    }

                    for (int i = 0; i < v1.Count; i++)
                    {
                        MotionEnd_LabelCollection[i].BackColor =
                            v1[i] ? Color.LightGreen : Color.White;
                    }

                    for (int i = 0; i < v2.Count; i++)
                    {
                        MotionDrive_LabelCollection[i].BackColor =
                            v2[i] ? Color.LightGreen : Color.White;
                    }
                    for (int i = 0; i < v3.Count; i++)
                    {
                        MotionAxis_textBoxCollection[i].Text =  v3[i].ToString();
                    }
                }));
            }
        }

        private void cbb_MotionState_CheckStateChanged(object sender, EventArgs e)
        {
            var state= ((CheckBox)sender).Checked;
            if (state)
            {
                cts = new CancellationTokenSource();
                Task.Run(() => { TestMonitoring(cts.Token); });
            }
                
            else
                cts.Cancel();
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
