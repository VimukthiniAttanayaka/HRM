import {CCol, CRow} from "@coreui/react-pro";

function Report() {
  return(
    <div>
      <h1>This is Generated Report</h1>
      <CRow>
        <CCol>Total Working Hours :</CCol>
        <CCol>160hrs</CCol>
      </CRow>
      <CRow>
        <CCol>Total Leaves taken For month :</CCol>
        <CCol>1</CCol>
      </CRow>
      <CRow>
        <CCol>Total Leaves taken For year :</CCol>
        <CCol>5</CCol>
      </CRow>
      <CRow>
        <CCol>Total Half-days taken For year :</CCol>
        <CCol>2</CCol>
      </CRow>
      <CRow>
        <CCol>Total Salary :</CCol>
        <CCol>LKR 542000</CCol>
      </CRow>
      <CRow>
        <CCol>Bonuses :</CCol>
        <CCol>LKR 20000</CCol>
      </CRow>
    </div>
  )
}
export default Report
