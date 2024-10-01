import React from 'react'
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
import {
  getMenu_HRM_ECustomer,
  getMenu_HRM_EEmployee,
  getMenu_HRM_EEmployeeJobDiscription,
  getMenu_HRM_EGroup,
  getMenu_HRM_AAttendanceSearch,
  getMenu_HRM_AMarkAttendance,
  getMenu_HRM_AGroup,
  getMenu_HRM_LGroup,
  getMenu_HRM_LLeaveSchedule,
  getMenu_HRM_LLeaveToApprove,
  getMenu_HRM_LLeaveEntitlement,
  getMenu_HRM_LLeaveType,
  getMenu_HRM_RPGroup,
  getMenu_HRM_RPHierarchyManagement,
  getMenu_HRM_RPReportingPerson,
  getMenu_HRM_RPReportingManagerSearch,
  getMenu_HRM_UMGroup,
  getMenu_HRM_UMInternalUser,
  getMenu_HRM_UMExternelUser,
  getMenu_HRM_UMUserRole,
  getMenu_HRM_UMAccessGroup,
  getMenu_HRM_UMMenuAccessGroup,
  getMenu_HRM_UMUserRoleAccessGroup,
  getMenu_HRM_UMUserMenu,
  getMenu_HRM_MDGroup,
  getMenu_HRM_MDBranch,
  getMenu_HRM_MDCountry,
  getMenu_HRM_MDDepartment,
  getMenu_HRM_MDJobRole,
} from './menuActivation'
import { getLabelText } from 'src/MultipleLanguageSheets'

let EGroup = getMenu_HRM_EGroup();
let ECustomer = getMenu_HRM_ECustomer();
let EEmployee = getMenu_HRM_EEmployee();
let EEmployeeJobDiscription = getMenu_HRM_EEmployeeJobDiscription();
let AGroup = getMenu_HRM_AGroup();
let AAttendanceSearch = getMenu_HRM_AAttendanceSearch();
let AMarkAttendance = getMenu_HRM_AMarkAttendance();
let LGroup = getMenu_HRM_LGroup();
let LLeaveSchedule = getMenu_HRM_LLeaveSchedule();
let LLeaveToApprove = getMenu_HRM_LLeaveToApprove();
let LLeaveEntitlement = getMenu_HRM_LLeaveEntitlement();
let LLeaveType = getMenu_HRM_LLeaveType();
let RPGroup = getMenu_HRM_RPGroup();
let RPHierarchyManagement = getMenu_HRM_RPHierarchyManagement();
let RPReportingPerson = getMenu_HRM_RPReportingPerson();
let RPReportingManagerSearch = getMenu_HRM_RPReportingManagerSearch();
let UMGroup = getMenu_HRM_UMGroup();
let UMInternalUser = getMenu_HRM_UMInternalUser();
let UMExternalUser = getMenu_HRM_UMExternelUser();
let UMUserRole = getMenu_HRM_UMUserRole();
let UMAccessGroup = getMenu_HRM_UMAccessGroup();
let UMMenuAccessGroup = getMenu_HRM_UMMenuAccessGroup();
let UMUserAccessGroup = getMenu_HRM_UMUserRoleAccessGroup();
let UMUserMenu = getMenu_HRM_UMUserMenu();
let MGroup = getMenu_HRM_MDGroup();
let MBranch = getMenu_HRM_MDBranch();
let MCountry = getMenu_HRM_MDCountry();
let MDepartment = getMenu_HRM_MDDepartment();
let MJobRole = getMenu_HRM_MDJobRole();


let templatetype_base = 'translation'
let templatetype = 'translation_navbar'

const _nav = [
  {
    component: CNavItem,
    // name: <Translation>{(t) => t('dashboard')}</Translation>,
    name: getLabelText('dashboard', templatetype),
    to: '/dashboard',
    icon: <CIcon icon={cilSpeedometer} customClassName="nav-icon" />,
    // badge: {
    //   color: 'info-gradient',
    //   text: 'NEW',
    // },
  }, {
    component: CNavGroup,
    // name: <Translation>{(t) => t('Employee Information')}</Translation>,
    name: getLabelText('Employee Information', templatetype), disabled: !EGroup,
    items: [
      {
        component: CNavItem,
        // name: <Translation>{(t) => t('Company')}</Translation>,
        name: getLabelText('Company', templatetype),
        to: '/employee/Company',
        disabled: !ECustomer,
      },
      {
        component: CNavItem,
        // name: <Translation>{(t) => t('Employee')}</Translation>,
        name: getLabelText('Employee', templatetype),
        to: '/employee/employee',
        disabled: !EEmployee,
        // isVisible:{getAttendance}
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
    // name: <Translation>{(t) => t('Attendance')}</Translation>,
    name: getLabelText('Attendance', templatetype),
    disabled: !AGroup,
    // to: '/buttons',
    // icon: <CIcon icon={cilCursor} customClassName="nav-icon" />,
    items: [
      {
        component: CNavItem,
        // name: <Translation>{(t) => t('Attendance Search')}</Translation>,
        name: getLabelText('Attendance Search', templatetype),
        to: '/attendance/attendance',
        disabled: !AAttendanceSearch,
        // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
      }, {
        component: CNavItem,
        // name: <Translation>{(t) => t('Mark Attendance')}</Translation>,
        name: getLabelText('Mark Attendance', templatetype),
        to: '/attendance/markattendance',
        disabled: !AMarkAttendance,
        // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
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
    // name: <Translation>{(t) => t('Leave Management')}</Translation>,
    name: getLabelText('Leave Management', templatetype),
    to: '/attendance/markattendance',
    disabled: !LGroup,
    items: [
      {
        component: CNavItem,
        // name: <Translation>{(t) => t('Leave Schedule')}</Translation>,
        name: getLabelText('Leave Schedule', templatetype),
        to: '/leaves/leaveshedule',
        disabled: !LLeaveSchedule,
        // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
      }, {
        component: CNavItem,
        // name: <Translation>{(t) => t('Leave To Approve')}</Translation>,
        name: getLabelText('Leave To Approve', templatetype),
        to: '/leaves/leavetoapprove',
        disabled: !LLeaveToApprove,
        // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
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
    disabled: !UMGroup,
    items: [{
      component: CNavItem,
      // name: <Translation>{(t) => t('User Access Group')}</Translation>,
      name: getLabelText('Attendance Report', templatetype),
      to: '/report/attendancereport',
      disabled: !UMUserAccessGroup,
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    }, {
      component: CNavItem,
      // name: <Translation>{(t) => t('User Access Group')}</Translation>,
      name: getLabelText('Birthday Report', templatetype),
      to: '/report/birthdayreport',
      disabled: !UMUserAccessGroup,
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    }]
  }, {
    component: CNavGroup,
    // name: <Translation>{(t) => t('Reports')}</Translation>,
    name: getLabelText('Log Reports', templatetype),
    disabled: !UMGroup,
    items: [{
      component: CNavItem,
      // name: <Translation>{(t) => t('User Access Group')}</Translation>,
      name: getLabelText('User Log', templatetype),
      to: '/logreports/userlog',
      disabled: !UMUserAccessGroup,
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    }, {
      component: CNavItem,
      // name: <Translation>{(t) => t('User Access Group')}</Translation>,
      name: getLabelText('Audit Log', templatetype),
      to: '/logreports/auditlog',
      disabled: !UMUserAccessGroup,
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    }, {
      component: CNavItem,
      // name: <Translation>{(t) => t('User Access Group')}</Translation>,
      name: getLabelText('Error Log', templatetype),
      to: '/logreports/errorlog',
      disabled: !UMUserAccessGroup,
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    }],
  },
  {
    component: CNavGroup,
    // name: <Translation>{(t) => t('User Management')}</Translation>,
    name: getLabelText('User Management', templatetype),
    disabled: !UMGroup,
    items: [{
      component: CNavItem,
      // name: <Translation>{(t) => t('Internal User')}</Translation>,
      name: getLabelText('Internal User', templatetype),
      to: '/users/internaluser',
      disabled: !UMInternalUser,
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    }, {
      component: CNavItem,
      // name: <Translation>{(t) => t('External User')}</Translation>,
      name: getLabelText('External User', templatetype),
      to: '/users/externaluser',
      disabled: !UMExternalUser,
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    }, {
      component: CNavItem,
      // name: <Translation>{(t) => t('User Role')}</Translation>,
      name: getLabelText('User Role', templatetype),
      to: '/users/userrole',
      disabled: !UMUserRole,
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    }, {
      component: CNavItem,
      // name: <Translation>{(t) => t('Access Group')}</Translation>,
      name: getLabelText('Access Group', templatetype),
      to: '/users/accessgroup',
      disabled: !UMAccessGroup,
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
      disabled: !UMUserMenu,
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    },],
  },
  {
    component: CNavGroup,
    // name: <Translation>{(t) => t('Master Data')}</Translation>,
    name: getLabelText('Master Data', templatetype),
    disabled: !MGroup,
    items: [{
      component: CNavItem,
      // name: <Translation>{(t) => t('Branch')}</Translation>,
      name: getLabelText('Branch', templatetype),
      to: '/masterdata/branch',
      disabled: !MBranch,
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
      disabled: !MDepartment,
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    }, {
      component: CNavItem,
      // name: <Translation>{(t) => t('Job Role')}</Translation>,
      name: getLabelText('Job Role', templatetype),
      to: '/masterdata/jobrole',
      disabled: !MJobRole,
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    }, {
      component: CNavItem,
      // name: <Translation>{(t) => t('Location (Address)')}</Translation>,
      name: getLabelText('Location (Address)', templatetype),
      to: '/masterdata/location',
      disabled: !MJobRole,
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    }, {
      component: CNavItem,
      // name: <Translation>{(t) => t('Leave Type')}</Translation>,
      name: getLabelText('Leave Type', templatetype),
      to: '/masterdata/leavetype',
      disabled: !LLeaveType,
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    },{
      component: CNavItem,
      // name: <Translation>{(t) => t('Leave Type')}</Translation>,
      name: getLabelText('Job Type', templatetype),
      to: '/masterdata/jobtype',
      disabled: !LLeaveType,
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    },{
      component: CNavItem,
      // name: <Translation>{(t) => t('Leave Type')}</Translation>,
      name: getLabelText('Salary Type', templatetype),
      to: '/masterdata/salarytype',
      disabled: !LLeaveType,
      // icon: <CIcon icon={cilPencil} customClassName="nav-icon" />,
    },],
  },
  {
    component: CNavItem,
    // name: <Translation>{(t) => t('Profile')}</Translation>,
    name: getLabelText('Profile', templatetype),
    to: '/profile',
  },
  {
    component: CNavItem,
    // name: <Translation>{(t) => t('Login')}</Translation>,
    name: getLabelText('Login', templatetype),
    to: '/login',
  },
  {
    component: CNavItem,
    // name: <Translation>{(t) => t('Forget Password')}</Translation>,
    name: getLabelText('Forget Password', templatetype),
    to: '/ForgetPassword',
  },
  // {
  //   component: CNavTitle,
  //   name: <Translation>{(t) => t('Templates')}</Translation>,
  // },
  // {
  //   component: CNavGroup,
  //   name: <Translation>{(t) => t('base')}</Translation>,
  //   to: '/base',
  //   icon: <CIcon icon={cilPuzzle} customClassName="nav-icon" />,
  //   items: [
  //     {
  //       component: CNavItem,
  //       name: 'Accordion',
  //       to: '/base/accordion',
  //     },
  //     {
  //       component: CNavItem,
  //       name: 'Breadcrumb',
  //       to: '/base/breadcrumbs',
  //     },
  //     {
  //       component: CNavItem,
  //       name: 'Cards',
  //       to: '/base/cards',
  //     },
  //     {
  //       component: CNavItem,
  //       name: 'Carousel',
  //       to: '/base/carousels',
  //     },
  //     {
  //       component: CNavItem,
  //       name: 'Collapse',
  //       to: '/base/collapses',
  //     },
  //     {
  //       component: CNavItem,
  //       name: 'List group',
  //       to: '/base/list-groups',
  //     },
  //     {
  //       component: CNavItem,
  //       name: 'Navs & Tabs',
  //       to: '/base/navs',
  //     },
  //     {
  //       component: CNavItem,
  //       name: 'Pagination',
  //       to: '/base/paginations',
  //     },
  //     {
  //       component: CNavItem,
  //       name: 'Placeholders',
  //       to: '/base/placeholders',
  //     },
  //     {
  //       component: CNavItem,
  //       name: 'Popovers',
  //       to: '/base/popovers',
  //     },
  //     {
  //       component: CNavItem,
  //       name: 'Progress',
  //       to: '/base/progress',
  //     },
  //     {
  //       component: CNavItem,
  //       name: 'Spinners',
  //       to: '/base/spinners',
  //     },
  //     {
  //       component: CNavItem,
  //       name: 'Tables',
  //       to: '/base/tables',
  //     },
  //     {
  //       component: CNavItem,
  //       name: 'Tooltips',
  //       to: '/base/tooltips',
  //     },
  //   ],
  // },
  // {
  //   component: CNavGroup,
  //   name: <Translation>{(t) => t('buttons')}</Translation>,
  //   to: '/buttons',
  //   icon: <CIcon icon={cilCursor} customClassName="nav-icon" />,
  //   items: [
  //     {
  //       component: CNavItem,
  //       name: 'Buttons',
  //       to: '/buttons/buttons',
  //     },
  //     {
  //       component: CNavItem,
  //       name: 'Buttons groups',
  //       to: '/buttons/button-groups',
  //     },
  //     {
  //       component: CNavItem,
  //       name: 'Dropdowns',
  //       to: '/buttons/dropdowns',
  //     },
  //     {
  //       component: CNavItem,
  //       name: 'Loading Buttons',
  //       to: '/buttons/loading-buttons',
  //       badge: {
  //         color: 'danger-gradient',
  //         text: 'PRO',
  //       },
  //     },
  //   ],
  // },
  // {
  //   component: CNavGroup,
  //   name: <Translation>{(t) => t('forms')}</Translation>,
  //   icon: <CIcon icon={cilNotes} customClassName="nav-icon" />,
  //   items: [
  //     {
  //       component: CNavItem,
  //       name: 'Form Control',
  //       to: '/forms/form-control',
  //     },
  //     {
  //       component: CNavItem,
  //       name: 'Select',
  //       to: '/forms/select',
  //     },
  //     {
  //       component: CNavItem,
  //       name: 'Multi Select',
  //       to: '/forms/multi-select',
  //       badge: {
  //         color: 'danger-gradient',
  //         text: 'PRO',
  //       },
  //     },
  //     {
  //       component: CNavItem,
  //       name: 'Checks & Radios',
  //       to: '/forms/checks-radios',
  //     },
  //     {
  //       component: CNavItem,
  //       name: 'Range',
  //       to: '/forms/range',
  //     },
  //     {
  //       component: CNavItem,
  //       name: 'Input Group',
  //       to: '/forms/input-group',
  //     },
  //     {
  //       component: CNavItem,
  //       name: 'Floating Labels',
  //       to: '/forms/floating-labels',
  //     },
  //     {
  //       component: CNavItem,
  //       name: 'Date Picker',
  //       to: '/forms/date-picker',
  //       badge: {
  //         color: 'danger-gradient',
  //         text: 'PRO',
  //       },
  //     },
  //     {
  //       component: CNavItem,
  //       name: 'Date Range Picker',
  //       to: '/forms/date-range-picker',
  //       badge: {
  //         color: 'danger-gradient',
  //         text: 'PRO',
  //       },
  //     },
  //     {
  //       component: CNavItem,
  //       name: 'Time Picker',
  //       to: '/forms/time-picker',
  //       badge: {
  //         color: 'danger-gradient',
  //         text: 'PRO',
  //       },
  //     },
  //     {
  //       component: CNavItem,
  //       name: 'Layout',
  //       to: '/forms/layout',
  //     },
  //     {
  //       component: CNavItem,
  //       name: 'Validation',
  //       to: '/forms/validation',
  //     },
  //   ],
  // },
  // {
  //   component: CNavGroup,
  //   name: <Translation>{(t) => t('icons')}</Translation>,
  //   icon: <CIcon icon={cilStar} customClassName="nav-icon" />,
  //   items: [
  //     {
  //       component: CNavItem,
  //       name: 'CoreUI Free',
  //       to: '/icons/coreui-icons',
  //       badge: {
  //         color: 'success-gradient',
  //         text: 'FREE',
  //       },
  //     },
  //     {
  //       component: CNavItem,
  //       name: 'CoreUI Flags',
  //       to: '/icons/flags',
  //     },
  //     {
  //       component: CNavItem,
  //       name: 'CoreUI Brands',
  //       to: '/icons/brands',
  //     },
  //   ],
  // },
  // {
  //   component: CNavGroup,
  //   name: <Translation>{(t) => t('notifications')}</Translation>,
  //   icon: <CIcon icon={cilBell} customClassName="nav-icon" />,
  //   items: [
  //     {
  //       component: CNavItem,
  //       name: 'Alerts',
  //       to: '/notifications/alerts',
  //     },
  //     {
  //       component: CNavItem,
  //       name: 'Badges',
  //       to: '/notifications/badges',
  //     },
  //     {
  //       component: CNavItem,
  //       name: 'Modal',
  //       to: '/notifications/modals',
  //     },
  //     {
  //       component: CNavItem,
  //       name: 'Toasts',
  //       to: '/notifications/toasts',
  //     },
  //   ],
  // },
  // {
  //   component: CNavItem,
  //   name: <Translation>{(t) => t('widgets')}</Translation>,
  //   to: '/widgets',
  //   icon: <CIcon icon={cilCalculator} customClassName="nav-icon" />,
  //   badge: {
  //     color: 'info-gradient',
  //     text: 'NEW',
  //   },
  // },
  // {
  //   component: CNavItem,
  //   name: 'Smart Table',
  //   icon: <CIcon icon={cilGrid} customClassName="nav-icon" />,
  //   badge: {
  //     color: 'danger-gradient',
  //     text: 'PRO',
  //   },
  //   to: '/smart-table',
  // },
  // {
  //   component: CNavTitle,
  //   name: <Translation>{(t) => t('plugins')}</Translation>,
  // },
  // {
  //   component: CNavItem,
  //   name: <Translation>{(t) => t('calendar')}</Translation>,
  //   icon: <CIcon icon={cilCalendar} customClassName="nav-icon" />,
  //   badge: {
  //     color: 'danger-gradient',
  //     text: 'PRO',
  //   },
  //   to: '/plugins/calendar',
  // },
  // {
  //   component: CNavItem,
  //   name: <Translation>{(t) => t('charts')}</Translation>,
  //   icon: <CIcon icon={cilChartPie} customClassName="nav-icon" />,
  //   to: '/plugins/charts',
  // },
  // {
  //   component: CNavItem,
  //   name: 'Google Maps',
  //   icon: <CIcon icon={cilMap} customClassName="nav-icon" />,
  //   badge: {
  //     color: 'danger-gradient',
  //     text: 'PRO',
  //   },
  //   to: '/plugins/google-maps',
  // },
  // {
  //   component: CNavTitle,
  //   name: <Translation>{(t) => t('extras')}</Translation>,
  // },
  // {
  //   component: CNavGroup,
  //   name: <Translation>{(t) => t('pages')}</Translation>,
  //   icon: <CIcon icon={cilStar} customClassName="nav-icon" />,
  //   items: [
  //     {
  //       component: CNavItem,
  //       name: <Translation>{(t) => t('login')}</Translation>,
  //       to: '/login',
  //     },
  //     {
  //       component: CNavItem,
  //       name: <Translation>{(t) => t('register')}</Translation>,
  //       to: '/register',
  //     },
  //     {
  //       component: CNavItem,
  //       name: <Translation>{(t) => t('error404')}</Translation>,
  //       to: '/404',
  //     },
  //     {
  //       component: CNavItem,
  //       name: <Translation>{(t) => t('error500')}</Translation>,
  //       to: '/500',
  //     },
  //   ],
  // },
  // {
  //   component: CNavGroup,
  //   name: <Translation>{(t) => t('apps')}</Translation>,
  //   icon: <CIcon icon={cilLayers} customClassName="nav-icon" />,
  //   items: [
  //     {
  //       component: CNavGroup,
  //       name: 'Invoicing',
  //       icon: <CIcon icon={cilSpreadsheet} customClassName="nav-icon" />,
  //       to: '/apps/invoicing',
  //       items: [
  //         {
  //           component: CNavItem,
  //           name: 'Invoice',
  //           badge: {
  //             color: 'danger-gradient',
  //             text: 'PRO',
  //           },
  //           to: '/apps/invoicing/invoice',
  //         },
  //       ],
  //     },
  //     {
  //       component: CNavGroup,
  //       name: 'Email',
  //       to: '/apps/email',
  //       icon: <CIcon icon={cilEnvelopeOpen} customClassName="nav-icon" />,
  //       items: [
  //         {
  //           component: CNavItem,
  //           name: 'Inbox',
  //           badge: {
  //             color: 'danger-gradient',
  //             text: 'PRO',
  //           },
  //           to: '/apps/email/inbox',
  //         },
  //         {
  //           component: CNavItem,
  //           name: 'Message',
  //           badge: {
  //             color: 'danger-gradient',
  //             text: 'PRO',
  //           },
  //           to: '/apps/email/message',
  //         },
  //         {
  //           component: CNavItem,
  //           name: 'Compose',
  //           badge: {
  //             color: 'danger-gradient',
  //             text: 'PRO',
  //           },
  //           to: '/apps/email/compose',
  //         },
  //       ],
  //     },
  //   ],
  // },
]

export default _nav
