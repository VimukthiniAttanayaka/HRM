import Dialog from '@mui/material/Dialog';
import DialogTitle from '@mui/material/DialogTitle';
import DialogContent from '@mui/material/DialogContent';
import DialogActions from '@mui/material/DialogActions';
import Button from '@mui/material/Button';

const PopUpAlert = ({ open, handleClose, dialogTitle, dialogContent }) => {
    return (
        <div>
            <Dialog
                onClose={handleClose} open={open}>
                <DialogTitle>{dialogTitle}</DialogTitle>
                <DialogContent>
                    <div>{dialogContent}</div>
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleClose}>Close</Button>
                </DialogActions>
            </Dialog>
        </div>
    );
};

export default PopUpAlert;
