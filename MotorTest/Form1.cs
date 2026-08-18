using ClassLibrary1.Motions._05.MotionState.Logic.Factorys;
using ClassLibrary1.Motions._98.MotorAxes;
using ClassLibrary1.Motions._98.MotorAxes.Factorys.Params;
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
        }

        private string GetDeviceKey(string Device, int HandlerNumber)
        {
            return $"{Device} + _ +  {HandlerNumber.ToString()}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var control = _context.GetMotionControls("Test");
            control.ConnectionMotionDevice();
        }

        private void TestMonitoring(CancellationToken token)
        {
            var control = _context.GetMotionControls("Test");

            while (!token.IsCancellationRequested)
            {
                var v = control["test"]?.GetState(StateMode.AJIN_DriveMechanical);
                var v1 = control["test"]?.GetState(StateMode.AJIN_ENDLogic);
                var v2 = control["test"]?.GetState(StateMode.AJIN_DriveMode);
            }
        }

        private void cbb_MotionState_CheckStateChanged(object sender, EventArgs e)
        {
            var state= ((CheckBox)sender).Checked;

            if (state)
                Task.Run(() => { TestMonitoring(cts.Token); });
            else
                cts.Cancel();
        }
    }
}
