import React, { useState, useEffect } from 'react'
import {
  CButton,
  CCard,
  CCardBody,
  CCol,
  CContainer,
  CForm,
  CFormInput,
  CInputGroup,
  CInputGroupText,
  CRow,
  CFormCheck,
  CFormSelect,
} from '@coreui/react-pro'
import CIcon from '@coreui/icons-react'
import { cilLockLocked, cilUser } from '@coreui/icons'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass';
import GoogleMaps, { GoogleMapsComponent } from './GoogleMaps';
import GPSLocation, { GPSLocationDetails } from '../../shared/GPSLocation.js';
import { AttendancePunch_Marker } from '../../../apicalls/attendance/add_new';


const MarkAttendance = () => {

  const apiUrl = process.env.REACT_APP_API_URL;

  const handleSubmit = async (event) => {
    event.preventDefault()

    // Validation (optional)
    // You can add validation logic here to check if all required fields are filled correctly

    // Prepare form data

    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(
        (position) => {
          let latitude;
          let longitude;

          latitude = position.coords.latitude;
          longitude = position.coords.longitude;

          const formData = {
            // CUS_ID: customerId,
            EAT_EmployeeID: 'sdfasf',
            EAT_Location_latitude: latitude,
            EAT_Location_longitude: longitude,
            UD_UserID: ''
          }

          console.log(formData)
          submitData(formData)
        })
    }

  }
  const submitData = async (formData) => {
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'attendance/AttendancePunch_Marker', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('Attendance Marked successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting Company data:', response.statusText)
    }
  }
  const [location, setLocation] = useState(null);
  const [locationMap, setLocationMap] = useState(null);

  useEffect(() => {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(
        (position) => {
          // console.log(position);
          // setLocation({
          //   latitude: position.coords.latitude,
          //   longitude: position.coords.longitude
          // });

          const formDataList = []

          const formData = {
            lat: position.coords.latitude,
            lng: position.coords.longitude,
            label: 'S',
            draggable: false,
            title: 'You Here',
          }

          formDataList[0] = formData;
          // formDataList[1] = formData;
          setLocationMap(formDataList)
          // console.log(formDataList);
          // console.log(location);
        },
        (error) => {
          console.error('Error getting location:', error);
        }
      );
    } else {
      console.error('Geolocation    API is not supported');
    }
  }, []);
  return (
    <div className="bg-body-tertiary min-vh-100 d-flex flex-row align-items-center">
      <CContainer>
        <CRow className="justify-content-center">
          <CCol md={9}>
            <CCard className="mx-4">
              <CCardBody className="p-4">
                <CForm onSubmit={handleSubmit}>
                  <h1>Mark</h1>
                  <p className="text-body-secondary">Mark Attendance</p>
                  {location == undefined ? '' :
                    <p className="text-body-secondary"> your location is {location.latitude} and {location.longitude}</p>
                  }
                  <GPSLocation location={location}></GPSLocation>
                  <GoogleMaps locations={locationMap} />


                  <div className="d-grid">
                    <CButton color="success" type='submit'>Submit</CButton>
                  </div>
                </CForm>
              </CCardBody>
            </CCard>
          </CCol>
        </CRow>
      </CContainer>
    </div>
  )
}

export default MarkAttendance
