import React from "react";
import { FormGroup } from "@material-ui/core";
import FieldBox from '../../atoms/FieldBox/FieldBox';
import "./CostFieldRow.scss";

const CostFieldRow = ({ fields, title, disabled, sizeType }) => {
    return (
        <>
            <div> {title} </div>
            <FormGroup row className="form-group">
            {fields.map(field => (
                <div className="parentCostField"> 
                    <div className="amountField">
                        <FieldBox 
                            key={field.amountField.name}
                            label={field.amountField.label}
                            inputType={field.amountField.inputType}
                            value={field.amountField.value}
                            unit={field.amountField.unit}
                            disabled={disabled}
                            sizeType={"input-text--medium"}
                            setRef={field.amountField.ref}
                        />
                    </div>
                    <div className="costField">
                        <FieldBox 
                            key={field.costField.name}
                            label={field.costField.label}
                            inputType={field.costField.inputType}
                            value={field.costField.value}
                            unit={field.costField.unit}
                            disabled={disabled}
                            sizeType={"input-text--medium"}
                            setRef={field.costField.ref}
                        />                 
                    </div>
                </div>
            ))}
            </FormGroup>
        </>
    );
}
 


export default CostFieldRow;
