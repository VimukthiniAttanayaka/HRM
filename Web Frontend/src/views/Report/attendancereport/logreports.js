import '../../AnkareReport/report.css'
// import ReportHome from "../../AnkareReport/ReportHome";
import ReportHome from './attendancereport'

function Report() {
  return(
    <div className={''} data-coreui-theme="light">
      <ReportHome></ReportHome>
    </div>
  )
}
export default Report
