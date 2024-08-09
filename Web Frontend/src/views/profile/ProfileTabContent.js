import profile_img from '../../assets/images/avatars/7.jpg'
import {CCol, CRow} from "@coreui/react-pro";
function ProfileTabContent({employeeData}) {

  return(
    <div>
      <CRow>
        <CCol>
          <img src={profile_img} alt="profile image" className={'mt-3 rounded-circle'}/>
        </CCol>
        <CCol>
          <h5 className={'mt-2'}>{employeeData.EME_FirstName} {employeeData.EME_LastName} <br/> {employeeData.EME_PrefferedName}</h5>
          <p className={'mb-2'}>{employeeData.EME_EmailAddress}</p>
          <h4>{employeeData.EME_PrefferedName}</h4>
          <p>
            Employee Id : {employeeData.EME_EmployeeID} <br/>
            Department Id : {employeeData.EME_DepartmentID}
          </p>
        </CCol>
      </CRow>
      <div className="">
        <CRow>
          <CCol className={'p-2 m-1'}>Reporting Manager :</CCol>
          <CCol className={'p-2 m-1 border rounded'}>{employeeData.EME_ReportingManager}</CCol>
        </CRow>
        <CRow>
          <CCol className={'p-2 m-1'}>Status</CCol>
          <CCol className={'p-2 m-1 border rounded'}>{employeeData.EME_Status && 'Active'}</CCol>
        </CRow>
        <CRow>
          <CCol className={'p-2 m-1'}>Employ Type</CCol>
          <CCol className={'p-2 m-1 border rounded'}>{employeeData.EME_EmployeeType}</CCol>
        </CRow>
        <CRow>
          <CCol className={'p-2 m-1'}>Payee Tax Number</CCol>
          <CCol className={'p-2 m-1 border rounded'}>{employeeData.EME_PayeeTaxNumber}</CCol>
        </CRow>
        <CRow>
          <CCol className={'p-2 m-1'}>Salary</CCol>
          <CCol className={'p-2 m-1 border rounded'}>LKR {employeeData.EME_Salary}</CCol>
        </CRow>
        <CRow>
          <CCol className={'p-2 m-1'}>Date of Birth</CCol>
          <CCol className={'p-2 m-1 border rounded'}>{employeeData.EME_DateOfBirth}</CCol>
        </CRow>
        <CRow>
          <CCol className={'p-2 m-1'}>Date of Hire</CCol>
          <CCol className={'p-2 m-1 border rounded'}>{employeeData.EME_DateOfHire}</CCol>
        </CRow>
        <CRow>
          <CCol className={'p-2 m-1'}>Gender</CCol>
          <CCol className={'p-2 m-1 border rounded'}>{employeeData.EME_Gender}</CCol>
        </CRow>
        <CRow>
          <CCol className={'p-2 m-1'}>Marital Status</CCol>
          <CCol className={'p-2 m-1 border rounded'}>{employeeData.EME_MaritalStatus}</CCol>
        </CRow>
        <CRow>
          <CCol className={'p-2 m-1'}>Nationality</CCol>
          <CCol className={'p-2 m-1 border rounded'}>{employeeData.EME_Nationality}</CCol>
        </CRow>
        <CRow>
          <CCol className={'p-2 m-1'}>Blood Group</CCol>
          <CCol className={'p-2 m-1 border rounded'}>{employeeData.EME_BloodGroup}</CCol>
        </CRow>
        <CRow>
          <CCol className={'p-2 m-1'}>NIC</CCol>
          <CCol className={'p-2 m-1 border rounded'}>{employeeData.EME_NIC}</CCol>
        </CRow>
        <CRow>
          <CCol className={'p-2 m-1'}>Passport</CCol>
          <CCol className={'p-2 m-1 border rounded'}>{employeeData.EME_Passport}</CCol>
        </CRow>
        <CRow>
          <CCol className={'p-2 m-1'}>Driving Licence</CCol>
          <CCol className={'p-2 m-1 border rounded'}>{employeeData.EME_DrivingLicense}</CCol>
        </CRow>
        {/*<CRow>*/}
        {/*  <CCol className={'p-2 m-1'}>Created by</CCol>*/}
        {/*  <CCol className={'p-2 m-1 border rounded'}>2023/11/12</CCol>*/}
        {/*/!*</CRow>*!/*/}
        {/*<CRow>*/}
        {/*  <CCol className={'p-2 m-1'}>Modified by</CCol>*/}
        {/*  <CCol className={'p-2 m-1 border rounded'}>self</CCol>*/}
        {/*</CRow>*/}
        {/*<CRow>*/}
        {/*  <CCol className={'p-2 m-1'}>Modified date time</CCol>*/}
        {/*  <CCol className={'p-2 m-1 border rounded'}>2025/03/12 12:27:11</CCol>*/}
        {/*</CRow>*/}
      </div>
    </div>
  )
}

export default ProfileTabContent
