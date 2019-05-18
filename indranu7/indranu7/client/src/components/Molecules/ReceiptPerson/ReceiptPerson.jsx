import React from 'react';

const ReceiptPerson = ({name, surname, id, address}) => (
<div>
    <table>
        <tr>
            <th>Vārds, uzvārds</th>
            <th>Personas kods</th>
            <th>Adrese</th>
        </tr>
        <tr>
            <td>Alfreds Futterkiste</td>
            <td>Maria Anders</td>
            <td>Germany</td>
        </tr>
    </table>
</div>
)

 
export default ReceiptPerson;