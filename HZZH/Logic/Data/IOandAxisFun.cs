using CommonRs;
using Device;
using HZZH.Logic.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Logic.Commmon
{
    public  class IOandAxisFun
    {
        public List<AxisClass> PolishX = new List<AxisClass>();
        public List<AxisClass> PolishY = new List<AxisClass>();
        public List<AxisClass> PolishZ = new List<AxisClass>();
        public List<AxisClass> PolishR = new List<AxisClass>();

        public List<AxisClass> SolderX = new List<AxisClass>();
        public List<AxisClass> SolderY = new List<AxisClass>();
        public List<AxisClass> SolderZ = new List<AxisClass>();
        public List<AxisClass> SolderR = new List<AxisClass>();
        public List<AxisClass> SolderS = new List<AxisClass>();

        public List<InputClass> PolishPlatFormIsHave = new List<InputClass>();
        public List<InputClass> SolderPlatFormIsHave = new List<InputClass>();
        /// <summary>
        /// 焊锡清洗电磁阀
        /// </summary>
        public List<OutputClass> Soldervalve = new List<OutputClass>();
        /// <summary>
        /// 打磨清洗电磁阀
        /// </summary>
        public List<OutputClass> Polishvalve = new List<OutputClass>();

        public IOandAxisFun()
        {
            PolishPlatFormIsHave.Add(DeviceRsDef.I_material2);
            PolishPlatFormIsHave.Add(DeviceRsDef.I_material5);
            SolderPlatFormIsHave.Add(DeviceRsDef.I_material3);
            SolderPlatFormIsHave.Add(DeviceRsDef.I_material6);

            PolishX.Add(DeviceRsDef.Axis_X3);
            PolishX.Add(DeviceRsDef.Axis_X4);

            PolishY.Add(DeviceRsDef.Axis_Y3);
            PolishY.Add(DeviceRsDef.Axis_Y4);

            PolishZ.Add(DeviceRsDef.Axis_Z3);
            PolishZ.Add(DeviceRsDef.Axis_Z4);

            PolishR.Add(DeviceRsDef.Axis_R3);
            PolishR.Add(DeviceRsDef.Axis_R4);

            SolderX.Add(DeviceRsDef.Axis_X1);
            SolderX.Add(DeviceRsDef.Axis_X2);

            SolderY.Add(DeviceRsDef.Axis_Y1);
            SolderY.Add(DeviceRsDef.Axis_Y2);

            SolderZ.Add(DeviceRsDef.Axis_Z1);
            SolderZ.Add(DeviceRsDef.Axis_Z2);

            SolderR.Add(DeviceRsDef.Axis_R1);
            SolderR.Add(DeviceRsDef.Axis_R2);

            SolderS.Add(DeviceRsDef.Axis_S1_1);
            SolderS.Add(DeviceRsDef.Axis_S1_2);
            SolderS.Add(DeviceRsDef.Axis_S2_1);
            SolderS.Add(DeviceRsDef.Axis_S2_2);

            Soldervalve.Add(DeviceRsDef.Q_LSolderEclean);
            Soldervalve.Add(DeviceRsDef.Q_RSolderEclean);
            Polishvalve.Add(DeviceRsDef.Q_LPolishBlow);
            Polishvalve.Add(DeviceRsDef.Q_RPolishBlow);
        }
        public bool allaixsarrive()
        {
            for (int i = 0; i <  DeviceRsDef.AxisList.Count; i++)
            {
                if (DeviceRsDef.AxisList[i].status != 0)
                {
                    return false;
                }
            }
            return true;
        }
        private bool trigBuff;
        /// <summary>
        /// 上升沿触发，持续一个扫描周期
        /// </summary>
        /// <param name="clk"></param>
        /// <returns></returns>
        public  bool R_Trig(bool clk)
        {
            if (clk != trigBuff)
            {
                trigBuff = clk;
                if (clk)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 下降沿触发，持续一个扫描周期
        /// </summary>
        /// <param name="clk"></param>
        /// <returns></returns>
        public bool F_Trig(bool clk)
        {
            if (clk != trigBuff)
            {
                trigBuff = clk;
                if (!clk)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 相机中心转换到打磨头
        /// </summary>
        /// <param name="id">平台编号</param>
        /// <param name="PolishPos">拍照给的打磨点数据</param>
        /// <returns></returns>
        public static PointF4 CameraToPolisherPos(int id, PointF4 PolishPos)
        {
            PointF4 f4 = new PointF4();
            f4.X = PolishPos.X + ProjectData.Instance.SaveData.PolishPlatform[id].machinePolishcarmera.X - ProjectData.Instance.SaveData.PolishPlatform[id].machinePolish.X;
            f4.Y = PolishPos.Y + ProjectData.Instance.SaveData.PolishPlatform[id].machinePolishcarmera.Y - ProjectData.Instance.SaveData.PolishPlatform[id].machinePolish.Y;
            f4.Z = PolishPos.Z;
            f4.R = PolishPos.R;
            return f4;
        }
        /// <summary>
        /// 相机中心到焊锡头转换
        /// </summary>
        /// <param name="id">平台编号</param>
        /// <param name="SolderPos">相机给的打磨点数据</param>
        /// <returns></returns>
        public static PointF4 CameraToSolderPos(int id, PointF4 SolderPos)
        {
            PointF4 f4 = new PointF4();
            f4.X = SolderPos.X + ProjectData.Instance.SaveData.SolderPlatform[id].machineSoldercamera.X - ProjectData.Instance.SaveData.SolderPlatform[id].machineSolder.X;
            f4.Y = SolderPos.Y + ProjectData.Instance.SaveData.SolderPlatform[id].machineSoldercamera.Y - ProjectData.Instance.SaveData.SolderPlatform[id].machineSolder.Y;
            f4.Z = SolderPos.Z;
            f4.R = SolderPos.R;
            return f4;
        }
        /// <summary>
        /// 计算旋转后位置
        /// </summary>
        /// <param name="usingPlatform">哪边</param>
        /// <param name="X">相机中心位置</param>
        /// <param name="Y"></param>
        /// <param name="Sx">焊头位置</param>
        /// <param name="Sy"></param>
        /// <param name="Sr"></param>
        /// <param name="Ang"></param>
        /// <param name="Tx"></param>
        /// <param name="Ty"></param>
        public static void Transorm(int ID, float X, float Y, float Sx, float Sy , float Ang, out float Tx, out float Ty)
        {
            TeachingMechinePra mechinePra = new TeachingMechinePra();

            PointF rotateCur = new PointF();
            rotateCur.X = Sx;
            rotateCur.Y = Sy;//装换前的角度和位置

            PointF rotateC = new PointF();//旋转中心
            double r = 0;

            mechinePra = ProjectData.Instance.SaveData.SolderPlatform[ID].teachingMechine;
            r = Ang;

            rotateC.X = X - mechinePra.RotatePstionCameraSize.X;
            rotateC.Y = Y - mechinePra.RotatePstionCameraSize.Y;

            double radius = mechinePra.Radius;//圆心半径
            Circle circle = new Circle(rotateC, (float)radius);

            PointF pos = circle.Rotate(rotateCur, r);

            Tx = pos.X;
            Ty = pos.Y;
        }

    }
    [Serializable]
    public class Circle
    {
        public PointF Center { get; set; }

        public float Radius { get; set; }
        public Circle()
        {

        }

        public Circle(PointF center, float radius)
        {
            this.Center = center;
            this.Radius = radius;
        }

        public PointF Rotate(PointF p, double r)
        {
            double rx = (p.X - Center.X) * Math.Cos(r) - (p.Y - Center.Y) * Math.Sin(r) + Center.X;
            double ry = (p.X - Center.X) * Math.Sin(r) + (p.Y - Center.Y) * Math.Cos(r) + Center.Y;

            return new PointF((float)rx, (float)ry);
        }

        /// <summary>
        /// 通过两点与旋转角度计算圆
        /// </summary>
        /// <param name="p1">首点</param>
        /// <param name="p2">末点</param>
        /// <param name="ang">从首点转动到末点的角度</param>
        /// <returns></returns>
        public static Circle CalcCircle(PointF p1, PointF p2, double ang)
        {
            Circle circle = new Circle();
            double a = 1 - Math.Cos(ang);
            double b = Math.Sin(ang);
            double c = -Math.Sin(ang);
            double d = 1 - Math.Cos(ang);

            double k = a * d - b * c;
            if (k == 0)
            {
                return circle;
            }

            double m = p2.X - p1.X * Math.Cos(ang) + p1.Y * Math.Sin(ang);
            double n = p2.Y - p1.X * Math.Sin(ang) - p1.Y * Math.Cos(ang);
            double x = (d * m - b * n) / k;
            double y = (-c * m + a * n) / k;
            circle.Center = new PointF((float)x, (float)y);
            circle.Radius = (float)Math.Sqrt(Math.Pow(x - p1.X, 2) + Math.Pow(y - p1.Y, 2));

            return circle;
        }

        public static Circle CalcCircle(PointF p1, PointF p2, PointF p3)
        {
            Circle circle = new Circle();
            float a, b, c, d, delta, m, n;
            float te, tf, tg;

            a = p2.X - p1.X;
            b = p2.Y - p1.Y;
            c = p3.X - p1.X;
            d = p3.Y - p1.Y;
            delta = a * d - b * c;
            m = (1.0f * p1.X * p1.X + 1.0f * p1.Y * p1.Y) - (1.0f * p2.X * p2.X + 1.0f * p2.Y * p2.Y);
            n = (1.0f * p1.X * p1.X + 1.0f * p1.Y * p1.Y) - (1.0f * p3.X * p3.X + 1.0f * p3.Y * p3.Y);
            if (Math.Abs(delta) > 0.00001)
            {
                te = (m / (float)delta) * d - (n / (float)delta) * b;
                tf = (n / (float)delta) * a - (m / (float)delta) * c;
                tg = -(1.0f * p1.X * te + 1.0f * p1.Y * tf + 1.0f * p1.X * p1.X + 1.0f * p1.Y * p1.Y);

                circle.Center = new PointF(-te / 2, -tf / 2);
                circle.Radius = (float)Math.Sqrt(te * te + tf * tf - 4 * tg) / 2;
            }

            return circle;

        }

        public static Circle FitCircle(PointF[] pointFs)
        {
            Circle circle = new Circle();
            if (pointFs.Length < 3)
            {
                return circle;
            }

            double x1 = 0.0;
            double x2 = 0.0;
            double x3 = 0.0;
            double y1 = 0.0;
            double y2 = 0.0;
            double y3 = 0.0;

            double x1y1 = 0;
            double x1y2 = 0;
            double x2y1 = 0;
            for (int i = 0; i < pointFs.Length; i++)
            {
                x1 = x1 + pointFs[i].X;
                x2 = x2 + pointFs[i].X * pointFs[i].X;
                x3 = x3 + pointFs[i].X * pointFs[i].X * pointFs[i].X;

                y1 = y1 + pointFs[i].Y;
                y2 = y2 + pointFs[i].Y * pointFs[i].Y;
                y3 = y3 + pointFs[i].Y * pointFs[i].Y * pointFs[i].Y;

                x1y1 = x1y1 + pointFs[i].X * pointFs[i].Y;
                x1y2 = x1y2 + pointFs[i].X * pointFs[i].Y * pointFs[i].Y;
                x2y1 = x2y1 + pointFs[i].X * pointFs[i].X * pointFs[i].Y;
            }

            double C = pointFs.Length * x2 - x1 * x1;
            double D = pointFs.Length * x1y1 - x1 * y1;
            double E = pointFs.Length * x3 + pointFs.Length * x1y2 - (x2 + y2) * x1;
            double G = pointFs.Length * y2 - y1 * y1;
            double H = pointFs.Length * x2y1 + pointFs.Length * y3 - (x2 + y2) * y1;
            double a = (H * D - E * G) / (C * G - D * D);
            double b = (H * C - E * D) / (D * D - G * C);
            double c = -(a * x1 + b * y1 + x2 + y2) / pointFs.Length;

            double centerX = a / (-2.0);
            double centerY = b / (-2.0);
            double radiuas = Math.Sqrt(a * a + b * b - 4 * c) / 2;
            circle.Center = new PointF((float)centerX, (float)centerY);
            circle.Radius = (float)radiuas;

            return circle;
        }


    }
}
