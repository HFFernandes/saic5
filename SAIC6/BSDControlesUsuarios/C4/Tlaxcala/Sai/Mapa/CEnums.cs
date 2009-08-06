using System;
using System.Collections.Generic;

using System.Text;
using ActualMap;
using System.Drawing;

namespace BSD.C4.Tlaxcala.Sai.Mapa
{
   public class CEnums
    {
        public CEnums()
        {
        }
        public static LineStyle getLineStyle(string linestyle)
        {
            LineStyle ls=LineStyle.Solid;//Valor por default
            switch (linestyle.ToLower())
            {
                case "arrowboth":
                    ls = LineStyle.ArrowBoth;
                    break;
                case "arrowend":
                    ls = LineStyle.ArrowEnd;
                    break;
                case "arrowstart":
                    ls = LineStyle.ArrowStart;
                    break;
                case "dualroad":
                    ls = LineStyle.DualRoad;
                    break;
                case "dashdotdotroad":
                    ls = LineStyle.DashDotDotRoad;
                    break;
                case "dashdotroad":
                    ls = LineStyle.DashDotRoad;
                    break;
                case "dotroad":
                    ls = LineStyle.DotRoad;
                    break;
                case "dashroad":
                    ls = LineStyle.DashRoad;
                    break;
                case "road":
                    ls = LineStyle.Road;
                    break;
                case "railroad":
                    ls = LineStyle.Railroad;
                    break;
                case "dashdotdot":
                    ls = LineStyle.DashDotDot;
                    break;
                case "dashdot":
                    ls = LineStyle.DashDot;
                    break;
                case "dot":
                    ls = LineStyle.Dot;
                    break;
                case "dash":
                    ls = LineStyle.Dash;
                    break;
                case "solid":
                    ls = LineStyle.Solid;
                    break;
                case "invisible":
                    ls = LineStyle.Invisible;
                    break;
                default:
                    ls = LineStyle.Solid;
                    break;
            }
            return ls;
        }
        public static FillStyle getFillStyle(string fillstyle)
        {
            FillStyle fs = FillStyle.Solid;//Valor por default
            switch (fillstyle.ToLower())
            {
                case "bitmap":
                    fs = FillStyle.Bitmap;
                    break;
                case "darkgray":
                    fs = FillStyle.DarkGray;
                    break;
                case "gray":
                    fs = FillStyle.Gray;
                    break;
                case "lightgray":
                    fs = FillStyle.LightGray;
                    break;
                case "diagonalcross":
                    fs = FillStyle.DiagonalCross;
                    break;
                case "cross":
                    fs = FillStyle.Cross;
                    break;
                case "downwarddiagonal":
                    fs = FillStyle.DownwardDiagonal;
                    break;
                case "upwarddiagonal":
                    fs = FillStyle.UpwardDiagonal;
                    break;
                case "vertical":
                    fs = FillStyle.Vertical;
                    break;
                case "horizontal":
                    fs = FillStyle.Horizontal;
                    break;
                case "solid":
                    fs = FillStyle.Solid;
                    break;
                case "invisible":
                    fs = FillStyle.Invisible;
                    break;
                default: 
                    fs = FillStyle.Solid;
                    break;
            }
            return fs;
        }
        public static Color getColor(string color)
        {
            Color col = Color.White;//Valor por default
            switch (color.ToLower())
            {
                case "aliceblue":
                    col = Color.AliceBlue;
                    break;
                case "antiquewhite":
                    col = Color.AntiqueWhite;
                    break;
                case "aqua":
                    col = Color.Aqua;
                    break;
                case "aquamarine":
                    col = Color.Aquamarine;
                    break;
                case "azure":
                    col = Color.Azure;
                    break;
                case "beige":
                    col = Color.Beige;
                    break;
                case "bisque":
                    col = Color.Bisque;
                    break;
                case "black":
                    col = Color.Black;
                    break;
                case "blanchedalmond":
                    col = Color.BlanchedAlmond;
                    break;
                case "blue":
                    col = Color.Blue;
                    break;
                case "blueviolet":
                    col = Color.BlueViolet;
                    break;
                case "brown":
                    col = Color.Brown;
                    break;
                case "burlywood":
                    col = Color.BurlyWood;
                    break;
                case "cadetblue":
                    col = Color.CadetBlue;
                    break;
                case "chartreuse":
                    col = Color.Chartreuse;
                    break;
                case "chocolate":
                    col = Color.Chocolate;
                    break;
                case "coral":
                    col = Color.Coral;
                    break;
                case "cornflowerblue":
                    col = Color.CornflowerBlue;
                    break;
                case "cornsilk":
                    col = Color.Cornsilk;
                    break;
                case "crimson":
                    col = Color.Crimson;
                    break;
                case "cyan":
                    col = Color.Cyan;
                    break;
                case "darkblue":
                    col = Color.DarkBlue;
                    break;
                case "darkcyan":
                    col = Color.DarkCyan;
                    break;
                case "darkgoldenrod":
                    col = Color.DarkGoldenrod;
                    break;
                case "darkgray":
                    col = Color.DarkGray;
                    break;
                case "darkgreen":
                    col = Color.DarkGreen;
                    break;
                case "darkkhaki":
                    col = Color.DarkKhaki;
                    break;
                case "darkmagenta":
                    col = Color.DarkMagenta;
                    break;
                case "darkolivegreen":
                    col = Color.DarkOliveGreen;
                    break;
                case "darkorange":
                    col = Color.DarkOrange;
                    break;
                case "darkorchid":
                    col = Color.DarkOrchid;
                    break;
                case "darkred":
                    col = Color.DarkRed;
                    break;
                case "darksalmon":
                    col = Color.DarkSalmon;
                    break;
                case "darkseagreen":
                    col = Color.DarkSeaGreen;
                    break;
                case "darkslateblue":
                    col = Color.DarkSlateBlue;
                    break;
                case "darkslategray":
                    col = Color.DarkSlateGray;
                    break;
                case "darkturquoise":
                    col = Color.DarkTurquoise;
                    break;
                case "darkviolet":
                    col = Color.DarkViolet;
                    break;
                case "deeppink":
                    col = Color.DeepPink;
                    break;
                case "deepskyblue":
                    col = Color.DeepSkyBlue;
                    break;
                case "dimgray":
                    col = Color.DimGray;
                    break;
                case "dodgerblue":
                    col = Color.DodgerBlue;
                    break;
                case "firebrick":
                    col = Color.Firebrick;
                    break;
                case "floralwhite":
                    col = Color.FloralWhite;
                    break;
                case "forestgreen":
                    col = Color.ForestGreen;
                    break;
                case "fuchsia":
                    col = Color.Fuchsia;
                    break;
                case "gainsboro":
                    col = Color.Gainsboro;
                    break;
                case "ghostwhite":
                    col = Color.GhostWhite;
                    break;
                case "gold":
                    col = Color.Gold;
                    break;
                case "goldenrod":
                    col = Color.Goldenrod;
                    break;
                case "gray":
                    col = Color.Gray;
                    break;
                case "green":
                    col = Color.Green;
                    break;
                case "greenyellow":
                    col = Color.GreenYellow;
                    break;
                case "honeydew":
                    col = Color.Honeydew;
                    break;
                case "hotpink":
                    col = Color.HotPink;
                    break;
                case "indianred":
                    col = Color.IndianRed;
                    break;
                case "indigo":
                    col = Color.Indigo;
                    break;
                case "ivory":
                    col = Color.Ivory;
                    break;
                case "khaki":
                    col = Color.Khaki;
                    break;
                case "lavender":
                    col = Color.Lavender;
                    break;
                case "lavenderblush":
                    col = Color.LavenderBlush;
                    break;
                case "lawngreen":
                    col = Color.LawnGreen;
                    break;
                case "lemonchiffon":
                    col = Color.LemonChiffon;
                    break;
                case "lightblue":
                    col = Color.LightBlue;
                    break;
                case "lightcoral":
                    col = Color.LightCoral;
                    break;
                case "lightcyan":
                    col = Color.LightCyan;
                    break;
                case "lightgoldenrodyellow":
                    col = Color.LightGoldenrodYellow;
                    break;
                case "lightgray":
                    col = Color.LightGray;
                    break;
                case "lightgreen":
                    col = Color.LightGreen;
                    break;
                case "lightpink":
                    col = Color.LightPink;
                    break;
                case "lightsalmon":
                    col = Color.LightSalmon;
                    break;
                case "lightseagreen":
                    col = Color.LightSeaGreen;
                    break;
                case "lightskyblue":
                    col = Color.LightSkyBlue;
                    break;
                case "lightslategray":
                    col = Color.LightSlateGray;
                    break;
                case "lightsteelblue":
                    col = Color.LightSteelBlue;
                    break;
                case "lightyellow":
                    col = Color.LightYellow;
                    break;
                case "lime":
                    col = Color.Lime;
                    break;
                case "limegreen":
                    col = Color.LimeGreen;
                    break;
                case "linen":
                    col = Color.Linen;
                    break;
                case "magenta":
                    col = Color.Magenta;
                    break;
                case "maroon":
                    col = Color.Maroon;
                    break;
                case "mediumaquamarine":
                    col = Color.MediumAquamarine;
                    break;
                case "mediumblue":
                    col = Color.MediumBlue;
                    break;
                case "mediumorchid":
                    col = Color.MediumOrchid;
                    break;
                case "mediumpurple":
                    col = Color.MediumPurple;
                    break;
                case "mediumseagreen":
                    col = Color.MediumSeaGreen;
                    break;
                case "mediumslateblue":
                    col = Color.MediumSlateBlue;
                    break;
                case "mediumspringgreen":
                    col = Color.MediumSpringGreen;
                    break;
                case "mediumturquoise":
                    col = Color.MediumTurquoise;
                    break;
                case "mediumvioletred":
                    col = Color.MediumVioletRed;
                    break;
                case "midnightblue":
                    col = Color.MidnightBlue;
                    break;
                case "mintcream":
                    col = Color.MintCream;
                    break;
                case "mistyrose":
                    col = Color.MistyRose;
                    break;
                case "moccasin":
                    col = Color.Moccasin;
                    break;
                case "navajowhite":
                    col = Color.NavajoWhite;
                    break;
                case "navy":
                    col = Color.Navy;
                    break;
                case "oldlace":
                    col = Color.OldLace;
                    break;
                case "olive":
                    col = Color.Olive;
                    break;
                case "olivedrab":
                    col = Color.OliveDrab;
                    break;
                case "orange":
                    col = Color.Orange;
                    break;
                case "orangered":
                    col = Color.OrangeRed;
                    break;
                case "orchid":
                    col = Color.Orchid;
                    break;
                case "palegoldenrod":
                    col = Color.PaleGoldenrod;
                    break;
                case "palegreen":
                    col = Color.PaleGreen;
                    break;
                case "paleturquoise":
                    col = Color.PaleTurquoise;
                    break;
                case "palevioletred":
                    col = Color.PaleVioletRed;
                    break;
                case "papayawhip":
                    col = Color.PapayaWhip;
                    break;
                case "peachpuff":
                    col = Color.PeachPuff;
                    break;
                case "peru":
                    col = Color.Peru;
                    break;
                case "pink":
                    col = Color.Pink;
                    break;
                case "plum":
                    col = Color.Plum;
                    break;
                case "powderblue":
                    col = Color.PowderBlue;
                    break;
                case "purple":
                    col = Color.Purple;
                    break;
                case "red":
                    col = Color.Red;
                    break;
                case "rosybrown":
                    col = Color.RosyBrown;
                    break;
                case "royalblue":
                    col = Color.RoyalBlue;
                    break;
                case "saddlebrown":
                    col = Color.SaddleBrown;
                    break;
                case "salmon":
                    col = Color.Salmon;
                    break;
                case "sandybrown":
                    col = Color.SandyBrown;
                    break;
                case "seagreen":
                    col = Color.SeaGreen;
                    break;
                case "seashell":
                    col = Color.SeaShell;
                    break;
                case "sienna":
                    col = Color.Sienna;
                    break;
                case "silver":
                    col = Color.Silver;
                    break;
                case "skyblue":
                    col = Color.SkyBlue;
                    break;
                case "slateblue":
                    col = Color.SlateBlue;
                    break;
                case "slategray":
                    col = Color.SlateGray;
                    break;
                case "snow":
                    col = Color.Snow;
                    break;
                case "springgreen":
                    col = Color.SpringGreen;
                    break;
                case "steelblue":
                    col = Color.SteelBlue;
                    break;
                case "tan":
                    col = Color.Tan;
                    break;
                case "teal":
                    col = Color.Teal;
                    break;
                case "thistle":
                    col = Color.Thistle;
                    break;
                case "tomato":
                    col = Color.Tomato;
                    break;
                case "turquoise":
                    col = Color.Turquoise;
                    break;
                case "violet":
                    col = Color.Violet;
                    break;
                case "wheat":
                    col = Color.Wheat;
                    break;
                case "white":
                    col = Color.White;
                    break;
                case "whitesmoke":
                    col = Color.WhiteSmoke;
                    break;
                case "yellow":
                    col = Color.Yellow;
                    break;
                case "yellowgreen":
                    col = Color.YellowGreen;
                    break;                
                default:
                    col = Color.White;
                    break;
            }
            return col;
        }
        public static PointStyle getPointStyle(string pointstyle)
        {
            PointStyle ps = PointStyle.Circle;//Valor por default
            switch (pointstyle.ToLower())
            {
                case "triangle":
                    ps = PointStyle.Triangle;
                    break;
                case "font":
                    ps = PointStyle.Font;
                    break;
                case "bitmap":
                    ps = PointStyle.Bitmap;
                    break;
                case "arrow":
                    ps = PointStyle.Arrow;
                    break;
                case "squarewithlargecenter":
                    ps = PointStyle.SquareWithLargeCenter;
                    break;
                case "squarewithsmallcenter":
                    ps = PointStyle.SquareWithSmallCenter;
                    break;
                case "circlewithlargecenter":
                    ps = PointStyle.CircleWithLargeCenter;
                    break;
                case "circlewithsmallcenter":
                    ps = PointStyle.CircleWithSmallCenter;
                    break;
                case "cross":
                    ps = PointStyle.Cross;
                    break;
                case "square":
                    ps = PointStyle.Square;
                    break;
                case "rhomb":
                    ps = PointStyle.Rhomb;
                    break;
                case "star":
                    ps = PointStyle.Star;
                    break;
                case "circle":
                    ps = PointStyle.Circle;
                    break;	
                default:
                    ps = PointStyle.Circle;
                    break;
            }
            return ps;
        }
    }
}
