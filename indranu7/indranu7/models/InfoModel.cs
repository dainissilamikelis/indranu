using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using indranu7.buisinessLogic;

namespace indranu7.models
{
    public class InfoModel
    {
        public int ApartmentNo { get; set; }
        public int TenantCount
        {
            get
            {
                var utils = new utils();
                return utils.GetDefaultTenantCount(ApartmentNo);
            }
        }
        public int DeclaredTenants
        {
            get
            {
                var utils = new utils();
                return utils.GetDefaultTenantCount(ApartmentNo);
            }
        }
        public decimal Area
        {
            get
            {
                var utils = new utils();
                return utils.GetApartmentArea(ApartmentNo);
            }
        }
        public decimal Rent
        {
            get
            {
                var utils = new utils();
                return utils.GetRent(ApartmentNo);
            }
        }
        public decimal Parking
        {
            get
            {
                var utils = new utils();
                return utils.GetParking(ApartmentNo);
            }
        }
        public decimal Heating { get; set; }
        public decimal HeatingCost { get; set; }

        public decimal HotWater { get; set; }
        public decimal HotWaterCost { get; set; }

        public decimal HotWaterLoss { get; set; }
        public decimal HotWaterLossCost { get; set; }

        public decimal ColdWater { get; set; }
        public decimal ColdWaterCost { get; set; }

        public decimal ColdWaterLoss { get; set; }
        public decimal ColdWaterLossCost { get; set; }

        public decimal WasteCost { get; set; }

        public decimal Upkeep { get; set; }
        public decimal UpkeepCost { get; set; }


        public decimal Tax { get; set; }
        public decimal Total
        {
            get
            {
                return Rent + Parking + HeatingCost + HotWaterCost + HotWaterLossCost + ColdWaterCost + ColdWaterLossCost + WasteCost + UpkeepCost + Tax;
            }
        }

    }
}
