import React, { useState, useEffect } from 'react';
import CIcon from '@coreui/icons-react'
import {
  cilBell,
  cilCalculator,
  cilCalendar,
  cilChartPie,
  cilCursor,
  cilDrop,
  cilEnvelopeOpen,
  cilGrid,
  cilLayers,
  cilMap,
  cilNotes,
  cilPencil,
  cilPuzzle,
  cilSpeedometer,
  cilSpreadsheet,
  cilStar,
} from '@coreui/icons'
import { CNavbarToggler, CNavGroup, CNavItem, CNavTitle } from '@coreui/react-pro'
import { Translation } from 'react-i18next'

import { getLabelText } from 'src/MultipleLanguageSheets'

let templatetype_base = 'translation'
let templatetype = 'translation_navbar'

// useEffect(() => {
//   // Simulate a delay or asynchronous operation to trigger the initial disabled state
//   setTimeout(() => {
//       // setIsNavGroupDisabled(true);
// console.log('hi')
//   }, 1000);
// }, []);

const _nav = [
  {
    component: CNavItem,
    // name: <Translation>{(t) => t('dashboard')}</Translation>,
    name: getLabelText('dashboard', templatetype),
    to: '/dashboard',
    keyname: "dashboard",
    icon: <CIcon icon={cilSpeedometer} customClassName="nav-icon" />,
    // badge: {
    //   color: 'info-gradient',
    //   text: 'NEW',
    // },
  },
  {
    component: CNavGroup,
    name: getLabelText('Employee Information', templatetype),
    items: [
      {
        component: CNavItem,
        name: getLabelText('Company', templatetype),
        to: '/employee/Company',
      },
      {
        component: CNavItem,
        name: getLabelText('Employee', templatetype),
        to: '/employee/employee',
      },
      // {
      //   component: CNavItem,
      //   // name: <Translation>{(t) => t('Employee')}</Translation>,
      //   name: getLabelText('Employee Excel Upload', templatetype),
      //   to: '/employee/employee_excelupload',
      //   // disabled: !EEmployee,
      //   // isVisible:{getAttendance}
      // }, ,
      //  {
      //   component: CNavItem,
      //   // name: <Translation>{(t) => t('Employee Job Desription')}</Translation>,
      //   name: getLabelText('Employee Job Desription', templatetype),
      //   to: '/employee/employeejobdescription',
      //   disabled: !EEmployeeJobDiscription,
      //   // isVisible:{getAttendance}
      // },
    ],
  },
  {
    component: CNavGroup,
    name: getLabelText('Attendance', templatetype),
    keyname: "getMenu_HRM_AGroup",
    items: [
      {
        component: CNavItem,
        name: getLabelText('Attendance Search', templatetype),
        to: '/attendance/attendance',
        keyname: "getMenu_HRM_AAttendanceSearch",
      }, {
        component: CNavItem,
        name: getLabelText('Mark Attendance', templatetype),
        to: '/attendance/markattendance',
      },
      //  {
      //   component: CNavItem,
      //   // name: <Translation>{(t) => t('Employee')}</Translation>,
      //   name: getLabelText('Attendance Excel Upload', templatetype),
      //   to: '/attendance/attendance_excelupload',
      //   // disabled: !EEmployee,
      //   // isVisible:{getAttendance}
      // }
    ],
  },
  {
    component: CNavGroup,
    name: getLabelText('Leave Management', templatetype),
    to: '/attendance/markattendance',
    items: [
      {
        component: CNavItem,
        name: getLabelText('Leave Schedule', templatetype),
        to: '/leaves/leaveshedule',
      }, {
        component: CNavItem,
        name: getLabelText('Leave To Approve', templatetype),
        to: '/leaves/leavetoapprove',
      },
      // {
      //   component: CNavItem,
      //   // name: <Translation>{(t) => t('Leave Entitlement')}</Translation>,
      //   name: getLabelText('Leave Entitlement', templatetype),
      //   to: '/leaves/leaveentitlement',
      //   disabled: !LLeaveEntitlement,
      //   // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
      // },

      // {
      //   component: CNavItem,
      //   // name: <Translation>{(t) => t('Leave Type')}</Translation>,
      //   name: getLabelText('Leave Entitlement Excel Upload', templatetype),
      //   to: '/leaves/leaveentitlement_excelupload',
      //   disabled: !LLeaveType,
      //   // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
      // },
    ],
  },
  // {
  //   component: CNavGroup,
  //   // name: <Translation>{(t) => t('performance appraisals')}</Translation>,
  //   name: getLabelText('Performance Appraisals', templatetype),
  //   items: [{
  //     component: CNavItem,
  //     // name: <Translation>{(t) => t('Hierarchy Management')}</Translation>,
  //     name: getLabelText('Questions', templatetype),
  //     to: '/performanceappriasals/questions',
  //     disabled: !RPHierarchyManagement,
  //     // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
  //   }, {
  //     component: CNavItem,
  //     // name: <Translation>{(t) => t('Hierarchy Management')}</Translation>,
  //     name: getLabelText('Answers', templatetype),
  //     to: '/performanceappriasals/answers',
  //     disabled: !RPHierarchyManagement,
  //     // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
  //   }, {
  //     component: CNavItem,
  //     // name: <Translation>{(t) => t('Hierarchy Management')}</Translation>,
  //     name: getLabelText('Questions List Upload', templatetype),
  //     to: '/performanceappriasals/questionslist_excelupload',
  //     disabled: !RPHierarchyManagement,
  //     // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
  //   }, {
  //     component: CNavItem,
  //     // name: <Translation>{(t) => t('Hierarchy Management')}</Translation>,
  //     name: getLabelText('Answers List Upload', templatetype),
  //     to: '/performanceappriasals/answerslist_excelupload',
  //     disabled: !RPHierarchyManagement,
  //     // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
  //   }, {
  //     component: CNavItem,
  //     // name: <Translation>{(t) => t('Hierarchy Management')}</Translation>,
  //     name: getLabelText('Answers Approval', templatetype),
  //     to: '/performanceappriasals/answersapproval',
  //     disabled: !RPHierarchyManagement,
  //     // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
  //   },]
  // },
  // {
  //   component: CNavGroup,
  //   // name: <Translation>{(t) => t('Reporting person')}</Translation>,
  //   name: getLabelText('Reporting person', templatetype), disabled: !RPGroup,
  //   items: [{
  //     component: CNavItem,
  //     // name: <Translation>{(t) => t('Hierarchy Management')}</Translation>,
  //     name: getLabelText('Hierarchy Management', templatetype),
  //     to: '/reportingperson/hierarchymanagement',
  //     disabled: !RPHierarchyManagement,
  //     // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
  //   },
  //   {
  //     component: CNavItem,
  //     // name: <Translation>{(t) => t('Reporting Manager Search')}</Translation>,
  //     name: getLabelText('Reporting Manager', templatetype),
  //     to: '/reportingperson/reportingmanager',
  //     disabled: !RPReportingManagerSearch,
  //     // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
  //   },],
  // },
  // {
  //   component: CNavTitle,
  //   name: <Translation>{(t) => t('Payroll management')}</Translation>,
  // },
  // {
  //   component: CNavTitle,
  //   name: <Translation>{(t) => t('New Joinee Management')}</Translation>,
  // },
  // {
  //   component: CNavGroup,
  //   name: getLabelText('Exit Interview', templatetype),
  //   // name: <Translation>{(t) => t('Exit Interview')}</Translation>,
  //   items: [
  //     //   {
  //     //   component: CNavItem,
  //     //   // name: <Translation>{(t) => t('User Access Group')}</Translation>,
  //     //   name: getLabelText('Exit Interview Questions', templatetype),
  //     //   to: '/exitinterview/exitinterviewquestions',
  //     //   // disabled: !UMUserAccessGroup,
  //     //   // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
  //     // }, {
  //     //   component: CNavItem,
  //     //   // name: <Translation>{(t) => t('User Access Group')}</Translation>,
  //     //   name: getLabelText('Exit Interview Answers', templatetype),
  //     //   to: '/exitinterview/exitinterviewanswers',
  //     //   // disabled: !UMUserAccessGroup,
  //     //   // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
  //     // }, {
  //     //   component: CNavItem,
  //     //   // name: <Translation>{(t) => t('Employee')}</Translation>,
  //     //   name: getLabelText('Exit Interview Answers Excel Upload', templatetype),
  //     //   to: '/exitinterview/exitinterviewanswers_excelupload',
  //     //   // disabled: !EEmployee,
  //     //   // isVisible:{getAttendance}
  //     // }, {
  //     //   component: CNavItem,
  //     //   // name: <Translation>{(t) => t('Employee')}</Translation>,
  //     //   name: getLabelText('Exit Interview Questions Excel Upload', templatetype),
  //     //   to: '/exitinterview/exitinterviewquestions_excelupload',
  //     //   // disabled: !EEmployee,
  //     //   // isVisible:{getAttendance}
  //     // },
  //     {
  //       component: CNavItem,
  //       // name: <Translation>{(t) => t('User Access Group')}</Translation>,
  //       name: getLabelText('Termination', templatetype),
  //       to: '/exitinterview/termination',
  //       // disabled: !UMUserAccessGroup,
  //       // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
  //     }]
  // },
  {
    component: CNavGroup,
    // name: <Translation>{(t) => t('Reports')}</Translation>,
    name: getLabelText('Reports', templatetype),
    items: [{
      component: CNavItem,
      // name: <Translation>{(t) => t('User Access Group')}</Translation>,
      name: getLabelText('Attendance Report', templatetype),
      to: '/report/attendancereport',
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    }, {
      component: CNavItem,
      // name: <Translation>{(t) => t('User Access Group')}</Translation>,
      name: getLabelText('Birthday Report', templatetype),
      to: '/report/birthdayreport',
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    }]
  }, {
    component: CNavGroup,
    // name: <Translation>{(t) => t('Reports')}</Translation>,
    name: getLabelText('Log Reports', templatetype),
    items: [{
      component: CNavItem,
      // name: <Translation>{(t) => t('User Access Group')}</Translation>,
      name: getLabelText('User Log', templatetype),
      to: '/logreports/userlog',
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    }, {
      component: CNavItem,
      // name: <Translation>{(t) => t('User Access Group')}</Translation>,
      name: getLabelText('Audit Log', templatetype),
      to: '/logreports/auditlog',
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    }, {
      component: CNavItem,
      // name: <Translation>{(t) => t('User Access Group')}</Translation>,
      name: getLabelText('Error Log', templatetype),
      to: '/logreports/errorlog',
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    }],
  },
  {
    component: CNavGroup,
    // name: <Translation>{(t) => t('User Management')}</Translation>,
    name: getLabelText('User Management', templatetype),
    items: [{
      component: CNavItem,
      // name: <Translation>{(t) => t('Internal User')}</Translation>,
      name: getLabelText('Internal User', templatetype),
      to: '/users/internaluser',
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    }, {
      component: CNavItem,
      // name: <Translation>{(t) => t('External User')}</Translation>,
      name: getLabelText('External User', templatetype),
      to: '/users/externaluser',
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    }, {
      component: CNavItem,
      // name: <Translation>{(t) => t('User Role')}</Translation>,
      name: getLabelText('User Role', templatetype),
      to: '/users/userrole',
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    }, {
      component: CNavItem,
      // name: <Translation>{(t) => t('Access Group')}</Translation>,
      name: getLabelText('Access Group', templatetype),
      to: '/users/accessgroup',
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    },
    // {
    //   component: CNavItem,
    //   // name: <Translation>{(t) => t('Menu Access Group')}</Translation>,
    //   name: getLabelText('Menu Access Group', templatetype),
    //   to: '/users/menuaccessgroup',
    //   disabled: !UMMenuAccessGroup,
    //   // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    // }, {
    //   component: CNavItem,
    //   // name: <Translation>{(t) => t('User Access Group')}</Translation>,
    //   name: getLabelText('User Access Group', templatetype),
    //   to: '/users/useraccessgroup',
    //   disabled: !UMUserAccessGroup,
    //   // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    // },
    {
      component: CNavItem,
      // name: <Translation>{(t) => t('User menu')}</Translation>,
      name: getLabelText('User menu', templatetype),
      to: '/users/usermenu',
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    },],
  },
  {
    component: CNavGroup,
    // name: <Translation>{(t) => t('Master Data')}</Translation>,
    name: getLabelText('Master Data', templatetype),
    items: [{
      component: CNavItem,
      // name: <Translation>{(t) => t('Branch')}</Translation>,
      name: getLabelText('Branch', templatetype),
      to: '/masterdata/branch',
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    }, {
      component: CNavItem,
      // name: <Translation>{(t) => t('Country')}</Translation>,
      name: getLabelText('Country', templatetype),
      to: '/masterdata/country',
      // disabled: !MCountry,
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    }, {
      component: CNavItem,
      // name: <Translation>{(t) => t('Department')}</Translation>,
      name: getLabelText('Department', templatetype),
      to: '/masterdata/department',
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    }, {
      component: CNavItem,
      // name: <Translation>{(t) => t('Job Role')}</Translation>,
      name: getLabelText('Job Role', templatetype),
      to: '/masterdata/jobrole',
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    }, {
      component: CNavItem,
      // name: <Translation>{(t) => t('Location (Address)')}</Translation>,
      name: getLabelText('Location (Address)', templatetype),
      to: '/masterdata/location',
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    }, {
      component: CNavItem,
      // name: <Translation>{(t) => t('Leave Type')}</Translation>,
      name: getLabelText('Leave Type', templatetype),
      to: '/masterdata/leavetype',
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    }, {
      component: CNavItem,
      // name: <Translation>{(t) => t('Leave Type')}</Translation>,
      name: getLabelText('Job Type', templatetype),
      to: '/masterdata/jobtype',
      keyname: "jobtype",
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    }, {
      component: CNavItem,
      // name: <Translation>{(t) => t('Leave Type')}</Translation>,
      name: getLabelText('Salary Type', templatetype),
      to: '/masterdata/salarytype',
      keyname: "salarytype",
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    },],
  },
  {
    component: CNavItem,
    // name: <Translation>{(t) => t('Profile')}</Translation>,
    name: getLabelText('Profile', templatetype),
    to: '/profile',
    keyname: "profile",
  },
  {
    component: CNavItem,
    // name: <Translation>{(t) => t('Login')}</Translation>,
    name: getLabelText('Login', templatetype),
    to: '/login',
    keyname: "login",
  },
  {
    component: CNavItem,
    // name: <Translation>{(t) => t('Forget Password')}</Translation>,
    name: getLabelText('Forget Password', templatetype),
    to: '/ForgetPassword',
    keyname: "ForgetPassword",
  },
]

export default _nav
