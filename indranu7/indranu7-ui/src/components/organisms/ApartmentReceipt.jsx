import React from 'react';

const tableStyle = {
  width: '100%',
  borderCollapse: 'collapse',
  margin: '2mm 2mm 2mm 2mm',
  maxWidth: '145mm',
  minWidth: '145mm',
  maxHeight: '205mm',
  minHeight: '205mm',
}

const tableColumHeaderStyle = {
  backgroundColor: '#f5d9b0',
}

const headerStyle = {
  backgroundColor: '#f7e7d0',
}

const TableSectionHeader = ({ label }) => (
  <tr style={headerStyle}>
    <th colSpan='4'>{label}</th>
  </tr>
)

const SectionHeader = ({ label }) => (
  <tr>
    <th colSpan='4'>{label}</th>
  </tr>
)

const LeftAlignCell = ({ text }) => (
  <td style={{ textAlign: 'left' }}> {text} </td>
)

const RigthAlignCell = ({ text }) => (
  <td style={{ textAlign: 'rigth' }}> {text} </td>
)

const ApartmentReceipt = ({
  info
}) => {
  return (
    <div>
      <table style={tableStyle} >
        <tbody>
          <SectionHeader label={`Rēķins Nr.I71906-01A ++++++++ ${info}`} />
          <tr>
            <th colSpan='2'> Maksājuma saņēmējs </th>
            <th colSpan='2'> Maksājuma veicējs </th>
          </tr>
          <tr>
            <td> Vārds, Uzvārds </td>
            <LeftAlignCell text="Inese Silamiķele" />
            <td> Vārds, Uzvārds </td>
            <LeftAlignCell text="Dāvis Sīmanis" />
          </tr>
          <tr>
            <td> Personas kods </td>
            <LeftAlignCell text="220263-10101" />
            <td> Personas kods </td>
            <LeftAlignCell text="" />
          </tr>
          <tr>
            <td> Līguma nummurs </td>
            <LeftAlignCell text="" />
          </tr>
          <SectionHeader label="Rēķina apmaksas datums 2019. gada 11. jūlijs" />
          <tr style={{ height: '4mm' }}></tr>
          <TableSectionHeader label="Komunālie maksājumi par 2019. gada maiju" />
          <tr style={tableColumHeaderStyle}>
            <td> Nosaukums </td>
            <td> Daudzums </td>
            <td> Tarifs </td>
            <td> Summa </td>
          </tr>
          <TableSectionHeader label="Ūdensapgāde" />
          <tr>
            <td> Patērētais ūdens </td>
            <td> 3.24 m3 </td>
            <td rowSpan="2"> 1.924 EUR/m3 </td>
            <td> 6.23 EUR </td>
          </tr>
          <tr>
            <td> Zudumi </td>
            <td> 1.69 m3 </td>
            <RigthAlignCell text="3.25 EUR" />
          </tr>
          <TableSectionHeader label="Siltumenerģija" />
          <tr>
            <td> Apkure </td>
            <td> 0.000 MWh </td>
            <td rowSpan="3"> 49.717 EUR/MWh </td>
            <td> 0.00 EUR </td>
          </tr>
          <tr>
            <td> Siltais ūdens </td>
            <td> 0.148 MWh </td>
            <td> 7.36 EUR </td>
          </tr>
          <tr>
            <td> Zudumi </td>
            <td> 0.062 MWh </td>
            <td> 3.08 EUR </td>
          </tr>
          <TableSectionHeader label="Elektroenerģija" />
          <tr>
            <td> Koplietošanas elektrība </td>
            <td> 6.62 kWh </td>
            <td> 0.150 EUR/kWh </td>
            <td> 0.99 EUR </td>
          </tr>
          <TableSectionHeader label="Atkritumu izvešana" />
          <tr>
            <td> Atkritumu izvešana </td>
            <td> 1 iedz. </td>
            <td> 2.380 EUR/iedz. </td>
            <td> 2.38 EUR </td>
          </tr>
          <TableSectionHeader label="Nodokļi" />
          <tr>
            <td> Īpašuma nodoklis </td>
            <td> 54.16 m2 </td>
            <td> 0.132 EUR/m2 </td>
            <td> 7.15 EUR </td>
          </tr>
          <tr>
            <td> Zemes nodoklis </td>
            <td> 25.04 m2 </td>
            <td> 0.094 EUR/m2 </td>
            <td> 2.35 EUR </td>
          </tr>
          <tr>
            <th colSpan="3" style={{ textAlign: 'right' }}> Kopā: </th>
            <th> 32.79 EUR </th>
          </tr>
          <TableSectionHeader label="Īres maksājumi" />
          <tr>
            <td> Dzīvoklis Nr.1 </td>
            <td />
            <td />
            <td> 77.00 EUR </td>
          </tr>
          <tr>
            <td > Stāvieta Nr.4 </td>
            <td />
            <td />
            <td> 25.00 EUR </td>
          </tr>
          <tr>
            <th colSpan='3' style={{ textAlign: 'right' }}> Kopā: </th>
            <th> 102.00 EUR </th>
          </tr>
          <tr>
            <th colSpan='3' style={{ textAlign: 'right' }}> Kopā apmaksai: </th>
            <th> 134.79 EUR </th>
          </tr>
          <tr>
            <th style={{ textAlign: 'right' }} colSpan='1'> Summa vārdos:  </th>
            <td colSpan='3'> Viens simts trīsdesmit pieci eiro un 52 centi </td>
          </tr>
          <tr style={{ height: '5mm' }}></tr>
          <tr>
            <td colSpan='2'> Maksājuma saņēmēja paraksts </td>
            <td colSpan='2'> Maksājuma veicēja paraksts </td>
          </tr>
          <tr>
            <td colSpan='4'> <p><i> Lūdzu veikt rēķina apmaksu uz līgumā norādīto izīrētāja bankas kontu, maksājuma uzdevumā norādot rēķina numuru</i> </p></td>
          </tr>
        </tbody>
      </table >
    </div >
  );
}

export default ApartmentReceipt;