import { MockResponseReceiptData } from "../api/api";

export function mapApartmentObjectToPreviewData(apartments) {

  const previewData = {
    apartmentNumber: [],
    tenants: [],
    apartmentArea: [],
    wasteSum: [],
    usedWater: [],
    usedWaterSum: [],
    usedWaterLoss: [],
    usedWaterLossSum: [],
    heat: [],
    heatSum: [],
    hotWater: [],
    hotWaterSum: [],
    heatLoss: [],
    heatLossSum: [],
    landTax: [],
    landTaxArea: [],
    apartmentTax: [],
    totalTaxSum: [],
    totalUtilitiesSum: [],
    rent: [],
    parking: [],
    totalRentSum: [],
    extraExpenditures: [],
    debt: [],
    totalSum: [],
  };

  MockResponseReceiptData.forEach((apartment) => {
    Object.keys(apartment).forEach(key => {
      previewData[key].push(apartment[key])
    })
  });

  return previewData;
}
