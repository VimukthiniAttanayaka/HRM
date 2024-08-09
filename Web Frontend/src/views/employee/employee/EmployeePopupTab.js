import React, { useState, useEffect } from 'react'
import { CTooltip, CRow, CButton, CModal, CTabs, CFormSelect, CTabList, CTab, CCol, CInputGroupText, CTabContent, CTabPanel, CModalBody, CModalTitle, CModalFooter, CFormCheck, CModalHeader, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup, CDatePicker } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import axios from 'axios';

const EmployeePopupTab = ({ visible, onClose, onOpen, EmployeeDetails, popupStatus }) => {

  const apiUrl = process.env.REACT_APP_API_URL;

  const [employeeId, setEmployeeId] = useState()
  const [firstName, setFirstName] = useState('')
  const [lastName, setLastName] = useState('')
  const [dob, setDob] = useState('1990-01-01')
  const [maritalStatus, setMaritalStatus] = useState('')
  const [gender, setGender] = useState('')
  const [nationality, setNationality] = useState('srilankan')
  const [bloodGroup, setBloodGroup] = useState('o+')
  const [prefferedName, setPrefferedName] = useState('')
  const [nic, setNic] = useState('')
  const [passport, setPassport] = useState('')
  const [drivingLicense, setDrivingLicense] = useState('')
  const [address, setAddress] = useState('')
  const [emailAddress, setEmailAddress] = useState('')
  const [mobileNumber, setMobileNumber] = useState('')
  const [phoneNumber1, setPhoneNumber1] = useState('')
  const [phoneNumber2, setPhoneNumber2] = useState('')
  const [jobTitle, setJobTitle] = useState('manager')
  const [department, setDepartment] = useState('management')
  const [reportingManager, setReportingManager] = useState('PIN1')
  const [dateOfHired, setDateOfHired] = useState('2024-01-01')
  const [employmentType, setEmploymentType] = useState('fullTime')
  const [salary, setSalary] = useState(0)
  const [additionalInformation, setAdditionalInformation] = useState('')
  const [tin, setTin] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeEmployeeId = (event) => {
    setEmployeeId(event.target.value)
  }
  const handleChangeFirstName = (event) => {
    setFirstName(event.target.value)
  }
  const handleChangeLastName = (event) => {
    setLastName(event.target.value)
  }
  const handleChangeDob = (event) => {
    setDob(event.target.value);
  }
  const handleChangeMaritalStatus = (event) => {
    setMaritalStatus(event.target.value)
  }
  const handleChangeGender = (event) => {
    setGender(event.target.value)
  }
  const handleChangeNationality = (event) => {
    setNationality(event.target.value)
  }
  const handleChangeBloodGroup = (event) => {
    setBloodGroup(event.target.value)
  }
  const handleChangePrefferedName = (event) => {
    setPrefferedName(event.target.value)
  }
  const handleChangeNicNumber = (event) => {
    setNic(event.target.value)
  }
  const handleChangePassportNumber = (event) => {
    setPassport(event.target.value)
  }
  const handleChangeDrivingLicenseNumber = (event) => {
    setDrivingLicense(event.target.value)
  }
  const handleChangeAddress = (event) => {
    setAddress(event.target.value)
  }
  const handleChangeEmailAddress = (event) => {
    setEmailAddress(event.target.value)
  }
  const handleChangeMobileNumber = (event) => {
    setMobileNumber(event.target.value)
  }
  const handleChangePhoneNumber1 = (event) => {
    setPhoneNumber1(event.target.value)
  }
  const handleChangePhoneNumber2 = (event) => {
    setPhoneNumber2(event.target.value)
  }
  const handleChangeJobTitle = (event) => {
    setJobTitle(event.target.value)
  }
  const handleChangeDepartment = (event) => {
    setDepartment(event.target.value)
  }
  const handleChangeReportingManager = (event) => {
    setReportingManager(event.target.value)
  }
  const handleChangeDateOfHired = (event) => {
    setDateOfHired(event.target.value)
  }
  const handleChangeEmploymentType = (event) => {
    setEmploymentType(event.target.value)
  }
  const handleChangeSalary = (event) => {
    setSalary(event.target.value)
  }
  const handleChangeAdditionalInformation = (event) => {
    setAdditionalInformation(event.target.value)
  }
  const handleChangeTin = (event) => {
    setTin(event.target.value)
  }
  const handleChangeStatus = (event) => {
    setIsActive(event.target.checked)
  }

  const handleCreate = async (event) => {

    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      EME_CustomerID: "string",
      EME_DepartmentID: department,
      EME_EmployeeID: employeeId,
      EME_FirstName: firstName,
      EME_LastName: lastName,
      EME_Gender: gender,
      EME_MaritalStatus: maritalStatus,
      EME_Nationality: nationality,
      EME_BloodGroup: bloodGroup,
      EME_NIC: nic,
      EME_Passport: passport,
      EME_DrivingLicense: drivingLicense,
      EME_PrefferedName: prefferedName,
      EME_JobTitle_Code: jobTitle,
      EME_ReportingManager: reportingManager,
      EME_EmployeeType: employmentType,
      EME_PayeeTaxNumber: tin,
      EME_Salary: 569,
      EME_Address: address,
      EME_EmailAddress: emailAddress,
      EME_MobileNumber: mobileNumber,
      EME_PhoneNumber1: phoneNumber1,
      EME_PhoneNumber2: phoneNumber2,
      EME_DateOfHire: dateOfHired,
      EME_Status: isActive,
      EME_DateOfBirth: dob,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'Employee/add_new_employee', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      onClose()
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('Department data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting Department data:', response.statusText)
    }
  }
  const handleEdit = async (event) => {
    // Prepare form data
    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      EME_CustomerID: "string",
      EME_DepartmentID: department,
      EME_EmployeeID: employeeId,
      EME_FirstName: firstName,
      EME_LastName: lastName,
      EME_Gender: gender,
      EME_MaritalStatus: maritalStatus,
      EME_Nationality: nationality,
      EME_BloodGroup: bloodGroup,
      EME_NIC: nic,
      EME_Passport: passport,
      EME_DrivingLicense: drivingLicense,
      EME_PrefferedName: prefferedName,
      EME_JobTitle_Code: jobTitle,
      EME_ReportingManager: reportingManager,
      EME_EmployeeType: employmentType,
      EME_PayeeTaxNumber: tin,
      EME_Salary: 568,
      EME_Address: address,
      EME_EmailAddress: emailAddress,
      EME_MobileNumber: mobileNumber,
      EME_PhoneNumber1: phoneNumber1,
      EME_PhoneNumber2: phoneNumber2,
      EME_DateOfHire: dateOfHired,
      EME_Status: isActive,
      EME_DateOfBirth: dob,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'Employee/modify_employee', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      onClose()
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('Department data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting Department data:', response.statusText)
    }
  }
  const handleDelete = async (event) => {
    console.log('Delete Department')
    // Prepare form data
    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      EME_EmployeeID: employeeId,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'Employee/inactivate_employee', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      onClose()
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('Department data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting Department data:', response.statusText)
    }
  }

  const handleSubmitData = async (event) => {
    event.preventDefault()

    if (popupStatus == 'create') {
      handleCreate(event)
    } else if (popupStatus == 'edit') {
      handleEdit(event)
    } else if (popupStatus == 'delete') {
      handleDelete(event)
    }

  }

  const popupStatusSetup = (event) => {

    if (popupStatus == 'edit') {
      return 'Edit Employee'
    } else if (popupStatus == 'view') {
      return 'View Employee'
    } else if (popupStatus == 'delete') {
      return 'Delete Employee'
    } else {
      return 'Create New Employee'
    }
  }

  const [selectedFileProfileImage, setSelectedFileProfileImage] = useState();
  const [selectedFileCV, setSelectedFileCV] = useState(null);
  const [selectedFileNIC, setSelectedFileNIC] = useState();
  const [selectedFilePassport, setSelectedFilePassport] = useState();
  const [selectedFileDrivingLicense, setSelectedFileDrivingLicense] = useState();

  function handleChangeProfileImage(e) {
    // console.log(e.target.files);
    setSelectedFileProfileImage(e.target.files[0]);
  }

  const handleFileChangeCV = (event) => {
    setSelectedFileCV(event.target.files[0]);
  };

  function handleChangeNIC(e) {
    // console.log(e.target.files);
    setSelectedFileNIC(e.target.files[0]);
  }

  function handleChangePassport(e) {
    // console.log(e.target.files);
    setSelectedFilePassport(e.target.files[0]);
  }

  function handleChangeDrivingLicense(e) {
    // console.log(e.target.files);
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

  // const handleSubmit1
  //   = async (event) => {
  //     event.preventDefault();
  //     const formData = new FormData();
  //     formData.append('file', selectedFile);

  //     try {
  //       const response = await axios.post('/api/upload',
  //         formData, {
  //         headers: {
  //           'Content-Type': 'multipart/form-data',
  //         },
  //       });
  //       console.log(response.data);
  //     } catch (error) {
  //       console.error(error);

  //     }
  //   };

  const handleSubmit = async (event) => {
    event.preventDefault();

    // const formData = new FormData();
    // formData.append('image', selectedFileProfileImage);

    // try {
    //   const response = await fetch(apiUrl + 'Employee/upload', {
    //     method: 'POST',
    //     body: formData,
    //   });

    //   const data = await response.json();
    //   console.log(data); // Handle success
    // } catch (error) {
    //   console.error(error); // Handle error
    // }
    const data = {
      EME_EmployeeID: 'employeeId',
    }
    const formData = new FormData();
    formData.append('cv', selectedFileCV);
    formData.append('nic', selectedFileNIC);
    formData.append('profileImage', selectedFileProfileImage);
    formData.append('passport', selectedFilePassport);
    formData.append('drivingLicense', selectedFileDrivingLicense);

    try {
      const response = await axios.post(apiUrl + 'Employee/PostImage',
        formData, {
        headers: {
          'Content-Type': 'multipart/form-data',
        },
      })
      const response1 = await axios.post(apiUrl + 'Employee/uploadAttachment',
        data, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      console.log(response.data);
    } catch (error) {
      console.error(error);
    }

  };

  useEffect(() => {
    if (popupStatus == 'create') {
      setEmployeeId('')
      setFirstName('')
      setLastName('')
      setMaritalStatus('')
      setGender('')
      setNationality('srilankan')
      setBloodGroup('o+')
      setPrefferedName('')
      setNic('')
      setPassport('')
      setDrivingLicense('')
      setAddress('')
      setEmailAddress('')
      setMobileNumber('')
      setPhoneNumber1('')
      setPhoneNumber2('')
      setJobTitle('manager')
      setDepartment('management')
      setReportingManager('PIN1')
      setEmploymentType('fullTime')
      setSalary(0)
      setAdditionalInformation('')
      setTin('')
      setIsActive(true)
    }
    else {
      const createdDOB = EmployeeDetails.EME_DateOfBirth;
      if (createdDOB !== undefined) {
        const dateOnly = createdDOB.slice(0, 10);
        setDob(dateOnly)
      }
      const createdDOH = EmployeeDetails.EME_DateOfHired;
      if (createdDOH !== undefined) {
        const dateOnly = createdDOH.slice(0, 10);
        setDob(dateOnly)
      }
      setEmployeeId(EmployeeDetails.EME_EmployeeID)
      setFirstName(EmployeeDetails.EME_FirstName)
      setLastName(EmployeeDetails.EME_LastName)
      setMaritalStatus(EmployeeDetails.EME_MaritalStatus)
      setGender(EmployeeDetails.EME_Gender)
      setNationality(EmployeeDetails.EME_Nationality)
      setBloodGroup(EmployeeDetails.EME_BloodGroup)
      setPrefferedName(EmployeeDetails.EME_PrefferedName)
      setNic(EmployeeDetails.EME_NIC)
      setPassport(EmployeeDetails.EME_Passport)
      setDrivingLicense(EmployeeDetails.EME_DrivingLicense)
      setAddress(EmployeeDetails.EME_Address)
      setEmailAddress(EmployeeDetails.EME_EmailAddress)
      setMobileNumber(EmployeeDetails.EME_MobileNumber)
      setPhoneNumber1(EmployeeDetails.EME_PhoneNumber1)
      setPhoneNumber2(EmployeeDetails.EME_PhoneNumber2)
      setJobTitle(EmployeeDetails.EME_JobTitle_Code)
      setDepartment(EmployeeDetails.EME_DepartmentID)
      setReportingManager(EmployeeDetails.EME_ReportingManager)
      setEmploymentType(EmployeeDetails.EME_EmployeeType)
      setSalary(EmployeeDetails.EME_Salary)
      setAdditionalInformation(EmployeeDetails.EME_AdditionalInformation)
      setTin(EmployeeDetails.EME_PayeeTaxNumber)
      setIsActive(EmployeeDetails.EME_Status)
    }
  }, [EmployeeDetails]);

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
          <CModalTitle id="TooltipsAndPopoverExample">{popupStatusSetup()}</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CTabs activeItemKey="general">
            <CTabList variant="tabs">
              <CTab itemKey="general">General</CTab>
              <CTab itemKey="profile">Profile</CTab>
              <CTab itemKey="contact">Contact</CTab>
              <CTab itemKey="employment">Employment</CTab>
            </CTabList>
            <CTabContent>
              <CTabPanel className="p-3" itemKey="general">
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Employee Id</h6>
                    </CInputGroupText>
                  </CCol>   <CFormInput placeholder="Employee ID" name="Employee ID" value={employeeId} onChange={handleChangeEmployeeId} disabled={popupStatus == 'create' ? false : true}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>FirstName</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="FirstName" name="FirstName"
                    value={firstName} onChange={handleChangeFirstName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>LastName</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="LastName" name="LastName"
                    value={lastName} onChange={handleChangeLastName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Date of birth</h6>
                    </CInputGroupText>
                  </CCol>
                  {/* <CDatePicker placeholder="Date of birth" name="dob"
                  value={dob} onChange={handleChangeDob}
                  /> */}
                  {/* <DatePicker onChange={handleChangeDob} value={dob} /> */}
                  <input
                    type="date"
                    id="dob"
                    name="dob"
                    value={dob}
                    onChange={handleChangeDob}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Gender</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormCheck inline type="radio" name="gender" id="inlineCheckbox1" value="male" label="Male" checked={gender === 'male'}
                    onChange={handleChangeGender} className='ms-4' />
                  <CFormCheck inline type="radio" name="gender" id="inlineCheckbox2" value="female" label="Female" checked={gender === 'female'}
                    onChange={handleChangeGender} />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Marital status</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormCheck inline type="radio" name="maritalStatus" id="inlineCheckbox1" value="singal" label="Single" checked={maritalStatus === 'singal'}
                    onChange={handleChangeMaritalStatus} className='ms-4' />
                  <CFormCheck inline type="radio" name="maritalStatus" id="inlineCheckbox2" value="married" label="Married" checked={maritalStatus === 'married'}
                    onChange={handleChangeMaritalStatus} />
                  <CFormCheck inline type="radio" name="maritalStatus" id="inlineCheckbox2" value="widowed" label="Widowed" checked={maritalStatus === 'widowed'}
                    onChange={handleChangeMaritalStatus} />
                  <CFormCheck inline type="radio" name="maritalStatus" id="inlineCheckbox2" value="divorced" label="Divorced" checked={maritalStatus === 'divorced'}
                    onChange={handleChangeMaritalStatus} />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Nationality/Country</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormSelect value={nationality} onChange={handleChangeNationality}>
                    <option value="srilankan">Srilankan</option>
                    <option value="indian">Indian</option>
                  </CFormSelect>
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Blood group</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormSelect value={bloodGroup} onChange={handleChangeBloodGroup}>
                    <option value="o+">O+</option>
                    <option value="o-">O-</option>
                    <option value="a+">A+</option>
                    <option value="a-">A-</option>
                    <option value="b+">B+</option>
                    <option value="b-">B-</option>
                    <option value="ab+">AB+</option>
                    <option value="ab-">AB-</option>
                  </CFormSelect>
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>PrefferedName</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="PrefferedName" name="prefferedName"
                    value={prefferedName} onChange={handleChangePrefferedName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>NIC</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="NIC" name="nic"
                    value={nic} onChange={handleChangeNicNumber}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Passport</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="Passport Number" name="passportNumber"
                    value={passport} onChange={handleChangePassportNumber}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Driving License</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="Driving License" name="drivingLicense"
                    value={drivingLicense} onChange={handleChangeDrivingLicenseNumber}
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
                    {selectedFileProfileImage && (
                      <img src={URL.createObjectURL(selectedFileProfileImage)} alt="Preview" width={100} />
                    )}
                    {/* <img src={selectedFileProfileImage} width={100} /> */}
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
                    {selectedFileNIC && (
                      <img src={URL.createObjectURL(selectedFileNIC)} alt="Preview" width={100} />
                    )}
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    <CCol md={4}>
                      <CInputGroupText>
                        <h6>Passport</h6>
                      </CInputGroupText>
                    </CCol>
                    <input type="file" onChange={handleChangePassport} />
                    {selectedFilePassport && (
                      <img src={URL.createObjectURL(selectedFilePassport)} alt="Preview" width={100} />
                    )}
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    <CCol md={4}>
                      <CInputGroupText>
                        <h6>Driving License</h6>
                      </CInputGroupText>
                    </CCol>
                    <input type="file" onChange={handleChangeDrivingLicense} />
                    {selectedFileDrivingLicense && (
                      <img src={URL.createObjectURL(selectedFileDrivingLicense)} alt="Preview" width={100} />
                    )}
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
                    value={address} onChange={handleChangeAddress}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>EmailAddress</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="EmailAddress" name="emailAddress"
                    value={emailAddress} onChange={handleChangeEmailAddress}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>MobileNumber</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="MobileNumber" name="mobileNumber"
                    value={mobileNumber} onChange={handleChangeMobileNumber}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>PhoneNumber1</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="PhoneNumber1" name="phoneNumber1"
                    value={phoneNumber1} onChange={handleChangePhoneNumber1}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>PhoneNumber2</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="PhoneNumber2" name="phoneNumber2"
                    value={phoneNumber2} onChange={handleChangePhoneNumber2}
                  />
                </CInputGroup>
              </CTabPanel>
              <CTabPanel className="p-3" itemKey="employment">
                <CForm onSubmit={handleSubmitData}>
                  <CInputGroup className="mb-3">
                    <CCol md={4}>
                      <CInputGroupText>
                        <h6>Job title</h6>
                      </CInputGroupText>
                    </CCol>
                    <CFormSelect value={jobTitle} onChange={handleChangeJobTitle}>
                      <option value="manager">Manager</option>
                      <option value="directer">Directer</option>
                      <option value="developer">Developer</option>
                      <option value="techLead">Tech lead</option>
                      {/* <option value="PIN">B+</option>
                    <option value="PWD">B-</option>
                    <option value="PIN">AB+</option>
                    <option value="PWD">AB-</option> */}
                    </CFormSelect>
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    <CCol md={4}>
                      <CInputGroupText>
                        <h6>Department</h6>
                      </CInputGroupText>
                    </CCol>
                    <CFormSelect value={department} onChange={handleChangeDepartment}>
                      <option value="management">Management</option>
                      <option value="hr">HR</option>
                      <option value="accounting">Accounting</option>
                      <option value="developer">Developer</option>
                      {/* <option value="PIN">B+</option>
                    <option value="PWD">B-</option>
                    <option value="PIN">AB+</option>
                    <option value="PWD">AB-</option> */}
                    </CFormSelect>
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    <CCol md={4}>
                      <CInputGroupText>
                        <h6>Reporting manager</h6>
                      </CInputGroupText>
                    </CCol>
                    <CFormSelect value={reportingManager} onChange={handleChangeReportingManager}>
                      <option value="PIN1">O+</option>
                      <option value="PWD2">O-</option>
                      <option value="PIN3">A+</option>
                      <option value="PWD4">A-</option>
                      <option value="PIN5">B+</option>
                      <option value="PWD6">B-</option>
                      <option value="PIN7">AB+</option>
                      <option value="PWD8">AB-</option>
                    </CFormSelect>
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    <CCol md={4}>
                      <CInputGroupText>
                        <h6>Date of hire</h6>
                      </CInputGroupText>
                    </CCol>
                    <input
                      type="date"
                      id="dob"
                      name="dateOfHired"
                      value={dateOfHired}
                      onChange={handleChangeDateOfHired}
                    />
                    {/* <CDatePicker placeholder="Date of hired" name="dateOfHired"
                  value={dateOfHired} onChange={handleChangeDateOfHired}
                  /> */}
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    <CCol md={4}>
                      <CInputGroupText>
                        <h6>Employment type</h6>
                      </CInputGroupText>
                    </CCol>
                    <CFormSelect value={employmentType} onChange={handleChangeEmploymentType}>
                      <option value="fullTime">full-time</option>
                      <option value="partTime">part-time</option>
                      <option value="contract">contract</option>
                    </CFormSelect>
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    <CCol md={4}>
                      <CInputGroupText>
                        <h6>Salary</h6>
                      </CInputGroupText>
                    </CCol> <CFormInput placeholder="Salary" name="salary" type='number'
                      value={salary} onChange={handleChangeSalary}
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
                      value={additionalInformation} onChange={handleChangeAdditionalInformation}
                    />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    <CCol md={4}>
                      <CInputGroupText>
                        <h6>Tax identification number(TIN)</h6>
                      </CInputGroupText>
                    </CCol> <CFormInput placeholder="TIN" name="tin"
                      value={tin} onChange={handleChangeTin}
                    />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    <CCol md={4}>
                      <CInputGroupText>
                        <h6>Status</h6>
                      </CInputGroupText>
                    </CCol>
                    <CFormCheck checked={isActive} onChange={handleChangeStatus} label="Status" disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} />
                  </CInputGroup>
                  <div className="d-grid">
                    {popupStatus == 'view' ? '' : (popupStatus == 'delete' ? <CButton color="danger" type='submit'>Delete</CButton> :
                      <CButton color="success" type='submit'>Submit</CButton>)}
                  </div>
                </CForm>
              </CTabPanel>
            </CTabContent>
          </CTabs>
        </CModalBody>
      </CModal>
    </>
  )
}
export default EmployeePopupTab
