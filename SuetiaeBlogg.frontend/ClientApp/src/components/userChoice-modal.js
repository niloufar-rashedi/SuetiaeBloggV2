import React from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal'

function UserChoice(props) {
    return (
        <Modal
            {...props}
            size="lg"
            aria-labelledby="contained-modal-title-vcenter"
            centered
        >
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">
                   Welcome to your profile
        </Modal.Title>
            </Modal.Header>
            <Modal.Footer>
                <Button onClick={props.onHide} href='/authorsdashboarad'>Go to the dashboard</Button>
                <Button onClick={props.onHide} href='/addposttrial'>Write a new blog post</Button>

            </Modal.Footer>
        </Modal> 
    );
}
export default UserChoice;