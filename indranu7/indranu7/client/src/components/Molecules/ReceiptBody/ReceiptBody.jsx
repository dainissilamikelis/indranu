import React from 'react';

const ReceiptBody = ({name, surname, id, address}) => (
<div>
    <table>
        <tr>
            <th colSpan="4">Īpašuma īre</th>
        </tr>
        <tr>
            <th>#</th>
            <th>Nosaukums</th>
            <th>Periods</th>
            <th>Maksa</th>
        </tr>
        <tr>
            <td>1</td>
            <td>Dzīvoklis</td>
            <td>Aprīlis, 2019</td>
            <td>100 EUR</td>
        </tr>
        <tr>
            <th>#</th>
            <th>Nosaukums</th>
            <th>Periods</th>
            <th>Maksa</th>
        </tr>
        <tr>
            <td>Centro comercial Moctezuma</td>
            <td>Francisco Chang</td>
            <td>Mexico</td>
        </tr>
        <tr>
            <td>Ernst Handel</td>
            <td>Roland Mendel</td>
            <td>Austria</td>
        </tr>
        <tr>
            <td>Island Trading</td>
            <td>Helen Bennett</td>
            <td>UK</td>
        </tr>
        <tr>
            <td>Laughing Bacchus Winecellars</td>
            <td>Yoshi Tannamuri</td>
            <td>Canada</td>
        </tr>
        <tr>
            <td>Magazzini Alimentari Riuniti</td>
            <td>Giovanni Rovelli</td>
            <td>Italy</td>
        </tr>
    </table>
</div>
)

 
export default ReceiptBody;