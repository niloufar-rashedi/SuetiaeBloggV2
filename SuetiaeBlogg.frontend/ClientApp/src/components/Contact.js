import React, { Component } from 'react'

export class Contact extends Component {
    render() {
        return (
            <div class="container p-4">
                <h3>Contact Us</h3>
                <div class="col">
                    <p class="text-justify">We love feedback, so drop us a line below using the contact form provided. Alternatively, direct email is ask [at] suetiaeblog [dot] com
                    SuetiaeBlog.com </p>
                    <p class="text-justify"> Lindholmspiren, 30 - Gothenburg, Sweden, 41 756</p>
                </div>

                <form class="text-center border border-light p-5" action="#!">

                    <p class="h4 mb-4">Contact us</p>
                    <input type="text" id="defaultContactFormName" class="form-control mb-4" placeholder="Name"/>
                    <input type="email" id="defaultContactFormEmail" class="form-control mb-4" placeholder="E-mail" />
                    <label>Subject</label>
                    <select class="browser-default custom-select mb-4">
                        <option value="" disabled>Choose option</option>
                        <option value="1" selected>Feedback</option>
                        <option value="2">Report a bug</option>
                        <option value="3">Feature request</option>
                        <option value="4">Feature request</option>
                    </select>
                    <div class="form-group">
                        <textarea class="form-control rounded-0" id="exampleFormControlTextarea2" rows="3" placeholder="Message"></textarea>
                    </div>
            
                    <button class="btn btn-info btn-block" type="submit">Send</button>

                </form >
            </div>
            );
    }
}
export default Contact