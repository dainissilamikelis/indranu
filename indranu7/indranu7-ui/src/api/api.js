import axios from 'axios';

function handleApiGet(url) {
  return axios.get(url)
    .then(response => response)
    .catch(error => console.log(url, error))
}

export function getApartmentData() {
  const url = 'https://localhost:44303/api/apartmentData'
  // const url = '/api/apartmentData';
  return handleApiGet(url);
}

export const MockResponseApartmentData = {
  apartments: [{
    apartmentNo: 1,
    tenantAmount: 1,
    debt: 0,
    debtInfo: "s",
    extraInfo: 's',
  }],
}

export const MockResponseReceiptData = [{
  apartmentNumber: 1,
  tenants: 1,
  apartmentArea: 54.16,
  wasteSum: 199,
  usedWater: 299,
  usedWaterSum: 399,
  usedWaterLoss: 499,
  usedWaterLossSum: 234,
  heat: 499,
  heatSum: 599,
  hotWater: 699,
  hotWaterSum: 799,
  heatLoss: 899,
  heatLossSum: 999,
  landTax: 188,
  landTaxArea: 44,
  apartmentTax: 288,
  totalTaxSum: 55,
  totalUtilitiesSum: 1337,
  rent: 100,
  parking: 0,
  totalRentSum: 100,
  extraExpenditures: 0,
  debt: 5,
  totalSum: 876,
}];
