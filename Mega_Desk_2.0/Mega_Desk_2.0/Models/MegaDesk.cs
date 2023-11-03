namespace Mega_Desk_2._0.Models
{
    public class MegaDesk
    {
        public int ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }
        public int Drawers { get; set; }
        public string SurfaceMaterial { get; set; }
        public int RushOrder { get; set; }
        public double Cost { get; set; }
        
        public DateTime Date { get; set; }

        public double CalculateCost()
        {
            double Cost = 0;
            double baseCost = 200;
            double surfaceArea = CalculateSurfaceArea();
            double drawerCost = CalculateDrawerCost();
            double surfaceMaterialCost = CalculateSurfaceMaterialCost();
            double rushCost = CalculateRush();
            double subtotal = baseCost + surfaceArea + drawerCost + surfaceMaterialCost + rushCost;
            Cost = subtotal;
            return Cost;
        }

        private double CalculateSurfaceArea()
        {
            double squareInPrice = 1.00;
            double surfaceArea = (Width * Depth) * squareInPrice;
            return surfaceArea;
        }

        private double CalculateDrawerCost()
        {
            double drawerCost = Drawers * 50.00;
            return drawerCost;
        }

        private double CalculateSurfaceMaterialCost()
        {
            double surfaceMaterialCost = 0;
            switch (SurfaceMaterial)
            {
                case "Oak":
                    surfaceMaterialCost = 200;
                    break;
                case "Laminate":
                    surfaceMaterialCost = 100;
                    break;
                case "Pine":
                    surfaceMaterialCost = 50;
                    break;
                case "Rosewood":
                    surfaceMaterialCost = 300;
                    break;
                case "Veneer":
                    surfaceMaterialCost = 125;
                    break;
            }
            return surfaceMaterialCost;
        }

        private double CalculateRush()
        { 
            double rushCost = 0;
            switch (RushOrder)
            { 
                case 3:
                    if (Width * Depth < 1000)
                    {
                        rushCost = 60;
                    }
                    else if (Width * Depth >= 1000 && Width * Depth <= 2000)
                    {
                        rushCost = 70;
                    }
                    else if (Width * Depth > 2000)
                    {
                        rushCost = 80;
                    }
                    break;
                case 5:
                    if (Width * Depth < 1000)
                    {
                        rushCost = 40;
                    }
                    else if (Width * Depth >= 1000 && Width * Depth <= 2000)
                    {
                        rushCost = 50;
                    }
                    else if (Width * Depth > 2000)
                    {
                        rushCost = 60;
                    }
                    break;
                case 7:
                    if (Width * Depth < 1000)
                    {
                        rushCost = 30;
                    }
                    else if (Width * Depth >= 1000 && Width * Depth <= 2000)
                    {
                        rushCost = 35;
                    }
                    else if (Width * Depth > 2000)
                    {
                        rushCost = 40;
                    }
                    break;
                default:
                     rushCost = 0;
                     break;
            }
            return rushCost;
        }
    }
}
