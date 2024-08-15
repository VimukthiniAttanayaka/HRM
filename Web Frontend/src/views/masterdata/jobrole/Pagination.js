import React, { useState } from 'react';
import { CPagination, CPaginationItem } from '@coreui/react-pro'

const Pagination = ({ totalItems, currentPage, setCurrentPage, itemsPerPage }) => {
  const pageCount = Math.ceil(totalItems / itemsPerPage);

  const pageNumbers = [];
  for (let i = 1; i <= pageCount; i++) {
    pageNumbers.push(i);
  }

  const handlePageChange = (page) => {
    setCurrentPage(page);
  };

  return (
    <div>
      <CPagination aria-label="Page navigation example">
        <CPaginationItem onClick={() => setCurrentPage(currentPage - 1)} disabled={currentPage === 1}>Previous</CPaginationItem>
        {pageNumbers.map(number => (
          <CPaginationItem key={number} onClick={() => handlePageChange(number)}>{number}</CPaginationItem>
        ))}
        <CPaginationItem onClick={() => setCurrentPage(currentPage + 1)} disabled={currentPage === pageCount}>Next</CPaginationItem>
      </CPagination>
    </div>
  );
};

export default Pagination;
