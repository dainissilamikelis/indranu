import React, { Component } from 'react';
import ApartmentReceiptInfo from '../molecules/ApartmentReceiptInfo';

class AllReceiptInfo extends Component {
  state = {
    apparmentInfo: [
      {
        apartmentNo: 1,
        tenantAmount: 0,
        goneDays: 0,
        debt: 0,
        debtInfo: '',
        extraInfo: '',
      },
      {
        apartmentNo: 2,
        tenantAmount: 0,
        goneDays: 0,
        debt: 0,
        debtInfo: '',
        extraInfo: '',
      },
      {
        apartmentNo: 3,
        tenantAmount: 0,
        goneDays: 0,
        debt: 0,
        debtInfo: '',
        extraInfo: '',
      },
      {
        apartmentNo: 4,
        tenantAmount: 0,
        goneDays: 0,
        debt: 0,
        debtInfo: '',
        extraInfo: '',
      },
      {
        apartmentNo: 5,
        tenantAmount: 0,
        goneDays: 0,
        debt: 0,
        debtInfo: '',
        extraInfo: '',
      }
    ]
  }
  render() {
    const { apparmentInfo } = this.state;
    return (
      <div>
        <h3> Dzīvokļu informācija (skaits, prombūtne) </h3>
        <div style={{ display: 'flex' }}>
          {
            apparmentInfo.map(info => (
              <ApartmentReceiptInfo
                apartmentNo={info.apartmentNo}
                tenantAmount={info.tenantAmount}
                debt={info.debt}
                debtInfo={info.debtInfo}
                extraInfo={info.extraInfo}
                onChange={this.handleChange}
              />
            ))
          }
        </div>
      </div>
    );
  }
}

export default AllReceiptInfo;