import React from 'react';
import AnkareReport from 'ankare-report';

const columns = [
  // ... column definitions
];

const data = [
  // ... data
];

function MyReport() {
  return (
    <AnkareReport
      title="My Report"
      subtitle="A sample report"
      logo="path/to/logo.png"
      columns={columns}
      dataSource={data}
    >
      <div className="summary">
        <h2>Summary</h2>
        <p>Total: {data.length}</p>
      </div>
    </AnkareReport>
  );
}

export default MyReport;