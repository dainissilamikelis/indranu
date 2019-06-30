import React, { Component } from 'react';
import ApartmentReceipt from '../organisms/ApartmentReceipt';

const groupStyle = {
  maxWidth: "100%",
  display: "flex",
  margin: 'auto',
};

class ApartmentPreview extends Component {
  render() {
    const {
      apartmentInfo,
    } = this.props;
    return (
      <div>
        {
          apartmentInfo.map(info => (
            <div key={info.id} style={groupStyle} >
              <ApartmentReceipt info={info} />
              <ApartmentReceipt info={info} />
            </div>
          ))
        }
      </div >
    );
  }
}

export default ApartmentPreview;