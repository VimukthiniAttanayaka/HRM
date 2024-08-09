import {CCol, CRow} from "@coreui/react-pro";

function UserProfileContact() {
  return (
    <div>
      <h5 className={'mt-2'}>FirstName LastName</h5>
      <p className={'mb-2'}>email@hmail.com</p>
      <CRow>
        <CCol className={'p-2 m-1'}>Address</CCol>
        <CCol className={'p-2 m-1 border rounded'}>House No, road, city</CCol>
      </CRow>
      <CRow>
        <CCol className={'p-2 m-1'}>Mobile</CCol>
        <CCol className={'p-2 m-1 border rounded'}>012-3456789</CCol>
      </CRow>
      <CRow>
        <CCol className={'p-2 m-1'}>Phone</CCol>
        <CCol className={'p-2 m-1 border rounded'}>012-3456789</CCol>
      </CRow>
    </div>
  )
}

export default UserProfileContact
