import React from 'react';
import PropTypes from 'prop-types';

const headerStyle = {
  backgroundColor: '#f7e7d0',
}

const tableStyle = {
  width: '100%',
  borderCollapse: 'collapse',
}

const cellStyle = {
  border: "solid",
  borderColor: 'black',
  borderWidth: 'thin',
}

const StyledCell = ({
  text,
  rowSpan,
  bold,
}) => {
  if (bold) {
    return (
      <td
        rowSpan={rowSpan}
        style={cellStyle}>
        <p>
          <b>
            {text}
          </b>
        </p>
      </td>
    )
  }

  return (
    <td rowSpan={rowSpan} style={cellStyle}>{text}</td>
  )
}

const RowInfo = ({
  label,
  unit,
  data,
  bold,
}) => (
    <tr>
      <StyledCell text={label} />
      <StyledCell text={unit} />
      {
        bold
          ? data.map(info => <StyledCell key={info} text={info} bold={bold} />)
          : data.map(info => <StyledCell key={info} text={info} />)
      }

    </tr>
  )

RowInfo.propTypes = {
  label: PropTypes.string.isRequired,
  unit: PropTypes.string.isRequired,
  bold: PropTypes.bool,
  data: PropTypes.array,
}

RowInfo.defaultProps = {
  bold: false,
  data: [],
}

const MultiRowInfo = ({
  label,
  unit,
  data,
  sum,
}) => (
    <>
      <tr>
        <StyledCell text={label} rowSpan={2} />
        <StyledCell text={unit} />
        {
          data.map(info => <StyledCell key={info} text={info} />)
        }
      </tr>
      <tr>
        <td>EUR</td>
        {
          sum.map(cost => <StyledCell key={cost} text={cost} />)
        }
      </tr>
    </>
  );

MultiRowInfo.propTypes = {
  label: PropTypes.string.isRequired,
  unit: PropTypes.string.isRequired,
  data: PropTypes.array,
  sum: PropTypes.array,
}

MultiRowInfo.defaultProps = {
  data: [],
  sum: [],
}

const TableSectionHeader = ({ label }) => (
  <tr style={headerStyle}>
    <th colSpan='16'>{label}</th>
  </tr>
)

const ReceiptOverView = ({ mappedApartmentData }) => {
  const {
    apartmentNumber,
    tenants,
    apartmentArea,
    wasteSum,
    usedWater,
    usedWaterSum,
    usedWaterLoss,
    usedWaterLossSum,
    heat,
    heatSum,
    hotWater,
    hotWaterSum,
    heatLoss,
    heatLossSum,
    landTax,
    landTaxArea,
    apartmentTax,
    totalTaxSum,
    totalUtilitiesSum,
    rent,
    parking,
    totalRentSum,
    extraExpenditures,
    debt,
    totalSum,
  } = mappedApartmentData;
  return (
    <table style={tableStyle}>
      <tbody>
        <TableSectionHeader label="Dzīvokļu informācija" />
        <RowInfo
          label="Dzīvoklis"
          unit="#"
          data={apartmentNumber}
        />
        <RowInfo
          label="Iedzīvotāji"
          unit="skaits"
          data={tenants}
        />
        <RowInfo
          label="Dzīvokļa platība"
          unit="m2"
          data={apartmentArea}
        />
        <RowInfo
          label="Atkritumi"
          unit="EUR"
          data={wasteSum}
        />
        <MultiRowInfo
          label="Patērētais ūdens"
          unit="m3"
          data={usedWater}
          sum={usedWaterSum}
        />
        <MultiRowInfo
          label="Ūdens zudumi"
          unit="m3"
          data={usedWaterLoss}
          sum={usedWaterLossSum}
        />
        <MultiRowInfo
          label="Apukre"
          unit="MWh"
          data={heat}
          sum={heatSum}
        />
        <MultiRowInfo
          label="Siltais ūdens"
          unit="MWh"
          data={hotWater}
          sum={hotWaterSum}
        />
        <MultiRowInfo
          label="Siltuma zudumi"
          unit="MWh"
          data={heatLoss}
          sum={heatLossSum}
        />
        <MultiRowInfo
          label="Īpašuma nodoklis"
          unit="m2"
          data={apartmentArea}
          sum={apartmentTax}
        />
        <MultiRowInfo
          label="Zemes nodoklis"
          unit="m2"
          data={landTaxArea}
          sum={landTax}
        />
        <RowInfo
          label="Visi nodokļi"
          unit="EUR"
          data={totalTaxSum}
        />
        <RowInfo
          label="Kopējā summa"
          unit="EUR"
          data={totalUtilitiesSum}
          bold
        />
        <TableSectionHeader label="Īres objekti" />
        <RowInfo
          label="Dzīvoklis"
          unit="EUR"
          data={rent}
        />
        <RowInfo
          label="Stāvieta"
          unit="EUR"
          data={parking}
        />
        <RowInfo
          label="Īres summa"
          unit="EUR"
          data={totalRentSum}
        />
        <RowInfo
          label="Papildus izdevumi"
          unit="EUR"
          data={extraExpenditures}
        />
        <RowInfo
          label="Parāds"
          unit="EUR"
          data={debt}
        />
        <RowInfo
          label="Kopējā rēķina summa"
          unit="EUR"
          data={totalSum}
          bold
        />
      </tbody>
    </table>
  )
}

export default ReceiptOverView;