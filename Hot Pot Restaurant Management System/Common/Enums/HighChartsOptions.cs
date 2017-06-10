using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Common.Enums
{
    
    public enum ChartType
    {
        area, 
        areaspline, 
        bar, 
        column, 
        line, 
        pie, 
        scatter, 
        spline, 
    }

    
    public enum AxisType
    {
        linear, 
        logarithmic, 
        datetime, 
        category, 
    }

    
    public enum Align
    {
        left,
        center,
        right,
    }

    
    public enum VerticalAlign
    {
        top,
        middle,
        bottom,
    }

    
    public enum AxisAlign
    {
        low,
        middle,
        high
    }
}