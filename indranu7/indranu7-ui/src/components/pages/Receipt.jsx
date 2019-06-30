import React, { Component } from 'react';
import FormField, { styles as type } from '../atoms/FormField';
import { Switch, Button, Spinner } from '@blueprintjs/core';
import _set from 'lodash.set';
import AllReceiptInfo from '../organisms/AllReceiptInfo';
import DualField from '../molecules/DualField';
import ApartmentReceiptPreview from '../templates/ApartmentReceiptPreview';
import ReactToPrint from 'react-to-print';
import SwitchField from '../atoms/Switch';
import ReceiptOverView from '../organisms/ReceiptOverView';
import { mapApartmentObjectToPreviewData } from '../../utils/utils';
import { MockResponseApartmentData, getApartmentData } from '../../api/api';
import axios from 'axios';

const groupStyle = {
  maxWidth: "100%",
  display: "flex",
};

const headerStyle = {
  maxWidth: "100%",
  display: "flex",
  margin: '10px',
};

class Receipt extends Component {
  state = {
    showApartmentInfo: true,
    winterMode: false,
    heat: 0,
    heatSum: 0,
    coldWater: 0,
    coldWaterSum: 0,
    hotWater: 0,
    eletricity: 0,
    eletricitySum: 0,
    waste: 0,
    tax: 0,
    apartmentData: {
      apartments: [],
    },
    apartmentInfo: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 15],
    mappedApartmentData: [],
    showReceiptData: false,
    loading: false,
    loadingApartmentData: false,
  }

  componentDidMount = () => {

    this.setState({ loadingApartmentData: true })

    // axios, get('https://localhost:44303/api/apartmentData').then(response => {
    //   debugger;
    // });
    getApartmentData().then((response) => {
      debugger;
      this.setState({
        loadingApartmentData: false,
        apartmentData: MockResponseApartmentData,
        mappedApartmentData: mapApartmentObjectToPreviewData(),
      })
    });


  }

  handleApartmentDataChange = (id, value) => {
    const { apartmentData } = this.state;
    const newApartmentData = _set(apartmentData, id, value);
    debugger;
    this.setState({ apartmentData: newApartmentData });
  }

  handleChange = (id, value) => {
    this.setState({ [id]: value })
  }

  handleShowApartmentInfo = () => {
    const { showApartmentInfo } = this.state;
    this.setState({ showApartmentInfo: !showApartmentInfo })
  }

  handleSetWinterMode = () => {
    const { winterMode } = this.state;
    this.setState({ winterMode: !winterMode })
  }

  handleShowReceipts = () => {
    const { showReceipts } = this.state;
    this.setState({ showReceipts: !showReceipts })
  }

  render() {
    const {
      showApartmentInfo,
      winterMode,
      showReceipts,
      heat,
      heatSum,
      coldWater,
      coldWaterSum,
      hotWater,
      eletricity,
      eletricitySum,
      waste,
      tax,
      apartmentInfo,
      mappedApartmentData,
      apartmentData,
      showReceiptData,
      loading,
      loadingApartmentData,
    } = this.state;

    const { apartments } = apartmentData;
    if (loadingApartmentData) return <Spinner />

    return (
      <div>
        <div style={headerStyle}>
          <SwitchField
            label="Parādīt dzīvokļu informāciju"
            onChange={this.handleShowApartmentInfo}
          />
          <SwitchField
            label="Parādīt rēķinus"
            onChange={this.handleShowReceipts}
          />
          <SwitchField
            label="Apkures sezona"
            onChange={this.handleSetWinterMode}
          />
        </div>
        <div hidden={showApartmentInfo}>
          <AllReceiptInfo
            apartmentData={apartments}
            onChange={this.handleApartmentDataChange}
          />
        </div>
        <div style={groupStyle}>
          <DualField
            id="heat"
            label="Siltums"
            unit='MWh'
            value={heat}
            valueSum={heatSum}
            onChange={this.handleChange}
          />
          <DualField
            id="coldWater"
            label="Aukstais ūdens"
            unit='m3'
            value={coldWater}
            valueSum={coldWaterSum}
            onChange={this.handleChange}
          />
          <DualField
            id="eletricity"
            label="Elektrība"
            unit='kWh'
            value={eletricity}
            valueSum={eletricitySum}
            onChange={this.handleChange}
          />
          <FormField
            id="hotWater"
            style={type.dual}
            label="Karstais ūdens, m3"
            onChange={this.handleChange}
            value={hotWater}
          />
          <FormField
            id="waste"
            style={type.dual}
            label="Atkritumi, EUR"
            onChange={this.handleChange}
            value={waste}
          />
          <FormField
            id="tax"
            style={type.dual}
            label="Nodoklis, EUR"
            onChange={this.handleChange}
            value={tax}
          />
        </div>
        <Button> Aprēķināt </Button>
        {
          loading
            ? (<Spinner />)
            : (
              <div hidden={!showReceiptData}>
                <ReactToPrint
                  trigger={() => <a href="#">Printēt rēķinus </a>}
                  content={() => this.componentRef}
                />
                <div>
                  <ReceiptOverView mappedApartmentData={mappedApartmentData} />
                </div>
                <div style={{ display: showReceipts ? 'block' : 'none' }}>
                  <ApartmentReceiptPreview ref={el => (this.componentRef = el)} apartmentInfo={apartmentInfo} hidden={true} />
                </div>
              </div>
            )
        }
      </div>
    );
  }
}




export default Receipt;