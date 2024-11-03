
import React, { useState, useEffect } from 'react'
import { CTooltip, CFormSelect, CButton, CCollapse, CCol, CCardFooter, CCard, CCardBody, CForm, CFormInput, CInputGroup, CDatePicker } from '@coreui/react-pro'
import { CFormLabel } from '@coreui/react';

const CollapseDropdownList = ({ optionsList, setSelectedOption, selectedOption, disabled, setSelectedValue, SelectedValue }) => {
    const [collapse, setCollapse] = useState(false);
    const [filterOptionList, setFilterOptionList] = useState([]);
    // const [SelectedValue, setSelectedValue] = useState('');

    const onEntering = () => { };
    const onEntered = () => { };
    const onExiting = () => { };
    const onExited = () => { };

    const onchange = (e) => {
        setCollapse(true)
        e.preventDefault();
        setFilterOptionList(optionsList)
        filterFunction(e.target.value)
    }

    const toggle = (show) => {
        setCollapse(show)
        // e.preventDefault();
    }

    function rowselect(key, value) {
        setSelectedOption(key)
        setSelectedValue(value)
        // console.log(key + '-' + value)
        setCollapse(false)
        // e.preventDefault();
    }

    function filterFunction(filter) {
        const regex = new RegExp(filter.toLowerCase() + '.*');
        let filteredList = optionsList.filter((user) => {
            return regex.test(user.value.toLowerCase());
        });

        // filteredList.unshift({ key: "__", value: "Please Select", disabled: false });

        // console.log(filter)
        if (filter == '') { setFilterOptionList(optionsList) }
        else { setFilterOptionList(filteredList) }
    }

    useEffect(() => {
        filterFunction('')
        // setFilterOptionList(optionsList)
    }, [optionsList]);

    return (
        <>
            <CCard>
                <CInputGroup>
                    {disabled === true ? '' :
                        <CCol>
                            <CFormInput placeholder="Click Here" onClick={() => { toggle(true) }} onChange={onchange} disabled={disabled} />
                        </CCol>}
                    {selectedOption === '' ? '' :
                        <CFormLabel>{selectedOption} - {SelectedValue}</CFormLabel>
                    }
                </CInputGroup>

                <CCollapse
                    visible={collapse}
                    onEntering={onEntering}
                    onEntered={onEntered}
                    onExiting={onExiting}
                    onExited={onExited}
                    disabled={disabled}
                >
                    <CCardBody>
                        <CCard>
                            <CButton color="danger" onClick={() => { toggle(false) }}>Hide</CButton>
                        </CCard>
                        {/* <CFormSelect
                            value={selectedOption}
                            // onChange={setSelectedOption}
                            onChange={(e) => setSelectedOption(e.target.value)}
                        > */}
                        {filterOptionList.map((option) => (
                            <CCard>
                                <CButton onClick={() => { rowselect(option.key, option.value) }}>{option.value}</CButton>
                            </CCard>
                            // <option key={option.key} value={option.key} disabled={option.disabled}>
                            //     {option.value}
                            // </option>
                        ))}
                        {/* </CFormSelect> */}
                    </CCardBody>
                </CCollapse>

            </CCard>
        </>
    )

}
export default CollapseDropdownList
