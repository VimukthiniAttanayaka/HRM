import React, { useState, useEffect } from 'react'
import { CImage, CCard, CCardBody } from '@coreui/react';
import ImageLoader from 'react-image-loader';

const ImageDisplay = ({ refresh,imageUrl }) => {
    // const [refresh, setRefresh] = useState(false);

    // const handleClick = () => {
    //     setRefresh(!refresh);
    // };

    // useEffect(() => {
    //     setRefresh(!refresh);
    //     console.log(refresh)
    // }, [imageUrl]);

    return (
        <div width="50%" height="50%">
            <CCard className="mx-4">
                <CCardBody className="p-4">
                    <ImageLoader
                        src={imageUrl}
                        alt="Image"
                        preloader={<div>Loading...</div>}
                        errorPlaceholder={<div>Error loading image</div>}
                    >
                        {refresh && (
                            <CImage
                                src={imageUrl}
                                alt="Image"
                                rounded thumbnail fluid
                                style={{ objectFit: 'cover' }}
                                width={50}
                                height={50}
                            />
                        )}

                    </ImageLoader>
                </CCardBody>
            </CCard>

        </div>
    );
};

export default ImageDisplay;
