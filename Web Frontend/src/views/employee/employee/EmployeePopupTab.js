import React, { useState, useEffect } from 'react'
import { CTooltip, CRow, CButton, CModal, CTabs, CFormSelect, CTabList, CTab, CCol, CInputGroupText, CTabContent, CTabPanel, CModalBody, CModalTitle, CModalFooter, CFormCheck, CModalHeader, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup, CDatePicker } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import axios from 'axios';
import { use } from 'i18next';

const EmployeePopupTab = ({ visible, onClose, onOpen }) => {
  const apiUrl = process.env.REACT_APP_API_URL;

  const [selectedFileProfileImage, setSelectedFileProfileImage] = useState();
  const [selectedFileCV, setSelectedFileCV] = useState(null);
  const [selectedFileNIC, setSelectedFileNIC] = useState([]);
  const [selectedFilePassport, setSelectedFilePassport] = useState();
  const [selectedFileDrivingLicense, setSelectedFileDrivingLicense] = useState();

  function handleChangeProfileImage(e) {
    console.log(e.target.files);
    setSelectedFileProfileImage(e.target.files[0]);
  }

  const handleFileChangeCV = (event) => {
    setSelectedFileCV(event.target.files[0]);
  };

  function handleChangeNIC(e) {
    console.log(e.target.files);
    setSelectedFileNIC(e.target.files[0]);
  }

  function handleChangePassport(e) {
    console.log(e.target.files);
    setSelectedFilePassport(e.target.files[0]);
  }

  function handleChangeDrivingLicense(e) {
    console.log(e.target.files);
    setSelectedFileDrivingLicense(e.target.files[0]);
  }
  // const handleImageChangeNIC = (event) => {
  //   const newImages = Array.from(event.target.files); // Convert FileList to array
  //   setSelectedFileNIC((prevImages) => [...prevImages, ...newImages]);
  // };

  // const handleRemoveImage = (index) => {
  //   setSelectedFileNIC((prevImages) => {
  //     const updatedImages = [...prevImages];
  //     updatedImages.splice(index, 1);
  //     return updatedImages;
  //   });
  // };

  const handleSubmit1
    = async (event) => {
      event.preventDefault();
      const formData = new FormData();
      formData.append('file', selectedFile);

      try {
        const response = await axios.post('/api/upload',
          formData, {
          headers: {
            'Content-Type': 'multipart/form-data',
          },
        });
        console.log(response.data);
      } catch (error) {
        console.error(error);

      }
    };

  const handleSubmit = async (event) => {
    event.preventDefault();
    console.log("hi")
    console.log(selectedFileProfileImage)
    // console.log(selectedFileCV)
    const formData = new FormData();
    // formData.append('image', selectedFileProfileImage);
    formData.append('cv', selectedFileCV);
    formData.append('nic', selectedFileNIC);
    formData.append('profileImage', selectedFileProfileImage);
    formData.append('passport', selectedFilePassport);
    formData.append('drivingLicense', selectedFileDrivingLicense);

    try {
      const response =
        // await fetch(apiUrl + 'Employee/PostImage', {
        //   method: 'POST',
        //   headers: { 'Content-Type': 'multipart/form-data' },
        //   body: formData,
        // })
        await axios.post(apiUrl + 'Employee/PostImage',
          formData, {
          headers: {
            'Content-Type': 'multipart/form-data',
          },
        });
      console.log(response.data);
    } catch (error) {
      console.error(error);
    }

  };

  var image;
  useEffect(() => {
    image = selectedFileProfileImage;
  }, [selectedFileProfileImage]);
  return (
    <>
      <CButton color="primary" onClick={onOpen}>Add New Employee</CButton>
      <CModal size='lg'
        scrollable
        alignment="center"
        visible={visible}
        onClose={onClose}
        aria-labelledby="TooltipsAndPopoverExample"
        backdrop="static"
      >
        <CModalHeader>
          <CModalTitle id="TooltipsAndPopoverExample">Create New Employee</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CTabs activeItemKey="general">
            <CTabList variant="tabs">
              <CTab itemKey="general">General</CTab>
              <CTab itemKey="profile">Profile</CTab>
              <CTab itemKey="contact">Contact</CTab>
              <CTab itemKey="employment">Employment</CTab>
              {/* <CTab disabled itemKey="disabled">Disabled</CTab> */}
            </CTabList>
            <CTabContent>
              <CTabPanel className="p-3" itemKey="general">
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>FirstName</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="FirstName" name="FirstName"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>LastName</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="LastName" name="LastName"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Date of birth</h6>
                    </CInputGroupText>
                  </CCol> <CDatePicker placeholder="Date of birth" name="dob"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Gender</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormCheck inline type="radio" name="inlineRadioOptions" id="inlineCheckbox1" value="option1" label="Male" className='ms-4' />
                  <CFormCheck inline type="radio" name="inlineRadioOptions" id="inlineCheckbox2" value="option2" label="Female" />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Marital status</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormCheck inline type="radio" name="inlineRadioOptions" id="inlineCheckbox1" value="option1" label="Male" className='ms-4' />
                  <CFormCheck inline type="radio" name="inlineRadioOptions" id="inlineCheckbox2" value="option2" label="Female" />
                  <CFormCheck inline type="radio" name="inlineRadioOptions" id="inlineCheckbox2" value="option2" label="Female" />
                  <CFormCheck inline type="radio" name="inlineRadioOptions" id="inlineCheckbox2" value="option2" label="Female" />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Nationality/Country</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormSelect>
                    <option value="PIN">Pin</option>
                    <option value="PWD">Password</option>
                  </CFormSelect>
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Blood group</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormSelect>
                    <option value="PIN">O+</option>
                    <option value="PWD">O-</option>
                    <option value="PIN">A+</option>
                    <option value="PWD">A-</option>
                    <option value="PIN">B+</option>
                    <option value="PWD">B-</option>
                    <option value="PIN">AB+</option>
                    <option value="PWD">AB-</option>
                  </CFormSelect>
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>PrefferedName</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="PrefferedName" name="PrefferedName"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>NIC</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="JobTitle_Code" name="JobTitle_Code"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Passport</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="JobTitle_Code" name="JobTitle_Code"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Driving License</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="JobTitle_Code" name="JobTitle_Code"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
              </CTabPanel>
              <CTabPanel className="p-3" itemKey="profile">
                <CForm onSubmit={handleSubmit}>
                  {/* <CInputGroup className="mb-3">
                    <CCol md={4}>
                      <CInputGroupText>
                        <h6>Document Name</h6>
                      </CInputGroupText>
                    </CCol>
                    <CFormSelect>
                      <option value="PIN">Profile Image</option>
                      <option value="PWD">CV</option>
                      <option value="PIN">NIC</option>
                      <option value="PWD">Passport</option>
                      <option value="PIN">Driving License</option>
                    </CFormSelect>
                  </CInputGroup> */}
                  <CInputGroup className="mb-3">
                    <CCol md={4}>
                      <CInputGroupText>
                        <h6>Profile Image</h6>
                      </CInputGroupText>
                    </CCol>
                    <input type="file" onChange={handleChangeProfileImage} />
                    <img src={selectedFileProfileImage} width={100} />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    <CCol md={4}>
                      <CInputGroupText>
                        <h6>CV</h6>
                      </CInputGroupText>
                    </CCol>
                    {/* <form onSubmit={handleSubmit1}> */}
                    <input type="file" onChange={handleFileChangeCV} />
                    {/* <button type="submit">Upload</button>
                  </form>  */}
                    {/* <input type="file" onChange={handleChangeProfileImage} />
                  <img src={selectedFileProfileImage} width={100} /> */}
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    <CCol md={4}>
                      <CInputGroupText>
                        <h6>NIC</h6>
                      </CInputGroupText>
                    </CCol>
                    <input type="file" onChange={handleChangeNIC} />
                    <img src={selectedFileNIC} width={100} />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    <CCol md={4}>
                      <CInputGroupText>
                        <h6>Passport</h6>
                      </CInputGroupText>
                    </CCol>
                    <input type="file" onChange={handleChangePassport} />
                    <img src={selectedFilePassport} width={100} />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    <CCol md={4}>
                      <CInputGroupText>
                        <h6>Driving License</h6>
                      </CInputGroupText>
                    </CCol>
                    <input type="file" onChange={handleChangeDrivingLicense} />
                    <img src={selectedFileDrivingLicense} width={100} />
                  </CInputGroup>
                  {/* <CInputGroup className="mb-3">
                    <CCol md={4}>
                      <CInputGroupText>
                        <h6>Profile Image</h6>
                      </CInputGroupText>
                    </CCol>
                    <CFormInput
                      id="profile-images"
                      type="file"
                      multiple // Allow selecting multiple files
                      onChange={handleImageChangeNIC}
                    />
                    {selectedFileNIC.map((imageFile, index) => (
                      <CCol key={index} md={4} className="d-flex align-items-center mb-2">
                        <img src={URL.createObjectURL(imageFile)} width={100} alt="Profile Image" />
                        <CButton variant="outline" colorScheme="red" ml={2} onClick={() => handleRemoveImage(index)}>
                          Remove
                        </CButton>
                      </CCol>
                    ))}
                  </CInputGroup> */}
                  <div className="d-grid">
                    <CButton color="success" type='submit'>Submit</CButton>
                  </div>
                </CForm>
                {/* <div className="App">
                  <h2>Profile Image:</h2>
                  <input type="file" onChange={handleChangeProfileImage} />
                  <img src={file} width={100} />
                </div> */}
              </CTabPanel>
              <CTabPanel className="p-3" itemKey="contact">
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Address</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="Address" name="Address"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>EmailAddress</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="EmailAddress" name="EmailAddress"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>MobileNumber</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="MobileNumber" name="MobileNumber"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>PhoneNumber1</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="PhoneNumber1" name="PhoneNumber1"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>PhoneNumber2</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="PhoneNumber2" name="PhoneNumber2"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
              </CTabPanel>
              <CTabPanel className="p-3" itemKey="employment">
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Job title</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormSelect>
                    <option value="PIN">O+</option>
                    <option value="PWD">O-</option>
                    <option value="PIN">A+</option>
                    <option value="PWD">A-</option>
                    <option value="PIN">B+</option>
                    <option value="PWD">B-</option>
                    <option value="PIN">AB+</option>
                    <option value="PWD">AB-</option>
                  </CFormSelect>
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Department</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormSelect>
                    <option value="PIN">O+</option>
                    <option value="PWD">O-</option>
                    <option value="PIN">A+</option>
                    <option value="PWD">A-</option>
                    <option value="PIN">B+</option>
                    <option value="PWD">B-</option>
                    <option value="PIN">AB+</option>
                    <option value="PWD">AB-</option>
                  </CFormSelect>
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Reporting manager</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormSelect>
                    <option value="PIN">O+</option>
                    <option value="PWD">O-</option>
                    <option value="PIN">A+</option>
                    <option value="PWD">A-</option>
                    <option value="PIN">B+</option>
                    <option value="PWD">B-</option>
                    <option value="PIN">AB+</option>
                    <option value="PWD">AB-</option>
                  </CFormSelect>
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Date of hire</h6>
                    </CInputGroupText>
                  </CCol> <CDatePicker placeholder="Date of birth" name="dob"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Employment type</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormSelect>
                    <option value="PIN">FullTime</option>
                    <option value="PWD">part-time</option>
                    <option value="PIN">contract</option>
                  </CFormSelect>
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Salary</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="JobTitle_Code" name="JobTitle_Code"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                {/* <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Benefits eligibility</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="JobTitle_Code" name="JobTitle_Code"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup> */}
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Additional Information</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="JobTitle_Code" name="JobTitle_Code"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Tax identification number(TIN)</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="JobTitle_Code" name="JobTitle_Code"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
              </CTabPanel>
              {/* <CTabPanel className="p-3" itemKey="disabled">
                Disabled tab content
              </CTabPanel> */}
            </CTabContent>
          </CTabs>
        </CModalBody>
      </CModal>
    </>
  )
}
export default EmployeePopupTab
