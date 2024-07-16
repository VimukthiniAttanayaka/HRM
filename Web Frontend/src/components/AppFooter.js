import React from 'react'
import { CFooter } from '@coreui/react-pro'

const AppFooter = () => {
  return (
    <CFooter className="px-4">
      {/* <div>
        <a href="" target="_blank" rel="noopener noreferrer">
          Doashait
        </a>
        <span className="ms-1">&copy; 2024 .</span>
      </div> */}
      <div className="ms-auto">
        <a
          href="https://coreui.io/product/react-dashboard-template/"
          target="_blank"
          rel="noopener noreferrer"
        >
          Doashait
        </a>
        <span className="me-1"> &copy; 2024 .</span>
      </div>
    </CFooter>
  )
}

export default React.memo(AppFooter)
