import React, { useState, useEffect } from 'react';

export function GPSLocationDetails(location) {
    useEffect(() => {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(
                (position) => {
                    location = position.coords;
                    return location;
                },
                (error) => {
                    console.error('Error getting location:', error);
                }
            );
        } else {
            console.error('Geolocation    API is not supported');
        }
    }, []);
}
// const GPSLocation = () => {
function GPSLocation() {
    const [location, setLocation] = useState(null);

    useEffect(() => {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(
                (position) => {
                    setLocation({

                        latitude: position.coords.latitude,
                        longitude: position.coords.longitude
                    });
                },
                (error) => {
                    console.error('Error getting location:', error);
                }
            );
        } else {
            console.error('Geolocation    API is not supported');
        }
    }, []);

    return (
        <div>
            {location ? (
                <p>Latitude: {location.latitude}, Longitude: {location.longitude}</p>
            ) : (
                <p>Location not available</p>
            )}
        </div>
    );
}
// }

export default GPSLocation
