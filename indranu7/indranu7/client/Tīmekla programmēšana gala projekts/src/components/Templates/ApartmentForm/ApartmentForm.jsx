import React from 'react';
import FieldBox from '../../atoms/FieldBox/FieldBox';
import './ApartmentForm.scss';
const ApartmentForm = ({ apartments }) => {
    return (  
        <div className="ApartmentForm">
            {apartments.map(apartment => (
                <div key={apartment.label} className="Apartment">
                    <h5>{ apartment.label }</h5>
                        {apartment.fields.map(field => (
                            <FieldBox
                            key={field.name}
                            label={field.label}
                            inputType={field.type}
                            unit={field.unit}
                            value={field.value}
                            setRef={field.ref}
                            sizeType={"input-text--small"}
                            />
                        ))}
                </div>
            ))}
        </div>
    );
}
export default ApartmentForm;
