import React, { useState } from 'react';

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
      {/* Pagination buttons */}
      <button onClick={() => setCurrentPage(currentPage - 1)} disabled={currentPage === 1}>Previous</button>
      {pageNumbers.map(number => (
        <button key={number} onClick={() => handlePageChange(number)}>{number}</button>
      ))}
      <button onClick={() => setCurrentPage(currentPage + 1)} disabled={currentPage === pageCount}>Next</button>
    </div>
  );
};

export default Pagination;
