import {CCol, CRow} from "@coreui/react-pro";

function UserProfileContact({employeeData}) {

  return (
    <div>
      <h5 className={'mt-2'}>{employeeData.EME_FirstName} {employeeData.EME_LastName}</h5>
      <p className={'mb-2'}>{employeeData.EME_EmailAddress}</p>
      <CRow>
        <CCol className={'p-2 m-1'}>Address</CCol>
        <CCol className={'p-2 m-1 border rounded'}>{employeeData.EME_Address}</CCol>
      </CRow>
      <CRow>
        <CCol className={'p-2 m-1'}>Mobile</CCol>
        <CCol className={'p-2 m-1 border rounded'}>{employeeData.EME_MobileNumber}</CCol>
      </CRow>
      <CRow>
        <CCol className={'p-2 m-1'}>Phone 1</CCol>
        <CCol className={'p-2 m-1 border rounded'}>{employeeData.EME_PhoneNumber1}</CCol>
      </CRow>
      <CRow>
        <CCol className={'p-2 m-1'}>Phone 2</CCol>
        <CCol className={'p-2 m-1 border rounded'}>{employeeData.EME_PhoneNumber2}</CCol>
      </CRow>
    </div>
  )
}

export default UserProfileContact
