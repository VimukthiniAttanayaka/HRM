import profile_img from '../../assets/images/avatars/7.jpg'
import {CCol, CRow} from "@coreui/react-pro";
function ProfileTabContent() {
  return(
    <div>
      <CRow>
        <CCol>
          <img src={profile_img} alt="profile image" className={'mt-3 rounded-circle'}/>
        </CCol>
        <CCol>
          <h5 className={'mt-2'}>FirstName LastName <br/> Preferred Name</h5>
          <p className={'mb-2'}>email@hmail.com</p>
          <h4>Job Title</h4>
          <p>
            Employee Id : 012 <br/>
            Department Id : S01
          </p>
        </CCol>
      </CRow>
      <div className="">
        <CRow>
          <CCol className={'p-2 m-1'}>Reporting Manager :</CCol>
          <CCol className={'p-2 m-1 border border-info rounded'}>name name</CCol>
        </CRow>
        <CRow>
          <CCol className={'p-2 m-1'}>Status</CCol>
          <CCol className={'p-2 m-1 border border-info rounded'}>Active</CCol>
        </CRow>
        <CRow>
          <CCol className={'p-2 m-1'}>Employ Type</CCol>
          <CCol className={'p-2 m-1 border border-info rounded'}>trainee</CCol>
        </CRow>
        <CRow>
          <CCol className={'p-2 m-1'}>Payee Tax Number</CCol>
          <CCol className={'p-2 m-1 border border-info rounded'}>tax num</CCol>
        </CRow>
        <CRow>
          <CCol className={'p-2 m-1'}>Salary</CCol>
          <CCol className={'p-2 m-1 border border-info rounded'}>LKR 550,000</CCol>
        </CRow>
        <CRow>
          <CCol className={'p-2 m-1'}>Address</CCol>
          <CCol className={'p-2 m-1 border border-info rounded'}>House No, road, city</CCol>
        </CRow>
        <CRow>
          <CCol className={'p-2 m-1'}>Date of Birth</CCol>
          <CCol className={'p-2 m-1 border border-info rounded'}>1520/06/30</CCol>
        </CRow>
        <CRow>
          <CCol className={'p-2 m-1'}>Date of Hire</CCol>
          <CCol className={'p-2 m-1 border border-info rounded'}>2023/03/15</CCol>
        </CRow>
        <CRow>
          <CCol className={'p-2 m-1'}>Mobile</CCol>
          <CCol className={'p-2 m-1 border border-info rounded'}>012-3456789</CCol>
        </CRow>
        <CRow>
          <CCol className={'p-2 m-1'}>Phone</CCol>
          <CCol className={'p-2 m-1 border border-info rounded'}>012-3456789</CCol>
        </CRow>
        <CRow>
          <CCol className={'p-2 m-1'}>Gender</CCol>
          <CCol className={'p-2 m-1 border border-info rounded'}>female</CCol>
        </CRow>
        <CRow>
          <CCol className={'p-2 m-1'}>Marital Status</CCol>
          <CCol className={'p-2 m-1 border border-info rounded'}>married</CCol>
        </CRow>
        <CRow>
          <CCol className={'p-2 m-1'}>Nationality</CCol>
          <CCol className={'p-2 m-1 border border-info rounded'}>Sri Lankan</CCol>
        </CRow>
        <CRow>
          <CCol className={'p-2 m-1'}>Blood Group</CCol>
          <CCol className={'p-2 m-1 border border-info rounded'}>A-</CCol>
        </CRow>
        <CRow>
          <CCol className={'p-2 m-1'}>NIC</CCol>
          <CCol className={'p-2 m-1 border border-info rounded'}>2134568988x</CCol>
        </CRow>
        <CRow>
          <CCol className={'p-2 m-1'}>Passport</CCol>
          <CCol className={'p-2 m-1 border border-info rounded'}>null</CCol>
        </CRow>
        <CRow>
          <CCol className={'p-2 m-1'}>Driving Licence</CCol>
          <CCol className={'p-2 m-1 border border-info rounded'}>null</CCol>
        </CRow>
        <CRow>
          <CCol className={'p-2 m-1'}>Created by</CCol>
          <CCol className={'p-2 m-1 border border-info rounded'}>2023/11/12</CCol>
        </CRow>
        <CRow>
          <CCol className={'p-2 m-1'}>Modified by</CCol>
          <CCol className={'p-2 m-1 border border-info rounded'}>self</CCol>
        </CRow>
        <CRow>
          <CCol className={'p-2 m-1'}>Modified date time</CCol>
          <CCol className={'p-2 m-1 border border-info rounded'}>2025/03/12 12:27:11</CCol>
        </CRow>
      </div>
    </div>
  )
}

export default ProfileTabContent
