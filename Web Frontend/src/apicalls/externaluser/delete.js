const apiUrl = process.env.REACT_APP_API_URL;

export const deleteExternalUser = async (formData) => {

  // Submit the form data to your backend API/
  const response = await fetch(apiUrl + 'ExternalUser/inactivate_user', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })

  if (response.ok) {
    console.log(response);
    // Handle successful submission (e.g., display a success message)
    console.log('Leave Type data submitted successfully!')
  } else {
    // Handle submission errors
    console.error('Error submitting Leave Type data:', response.statusText)
  }
};
