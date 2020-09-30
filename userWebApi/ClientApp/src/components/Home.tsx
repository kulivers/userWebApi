import * as React from 'react';

class Home extends React.Component {
    constructor(props) {
        super(props);
        this.state = { name: '', isMale: true, education: 'High', hasCar: false, message: '' };
    }

    handleChange = (event) => {
        this.setState({ [event.target.name]: event.target.value });
    }

    handleBoolChange = (event) => {
        this.setState({ [event.target.name]: event.target.value !== "false" });
    }

    handleSubmit = (event) => {
        var that = this;
        fetch('api/UserRegister', {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            // We convert the React state to JSON and send it as the POST body
            body: JSON.stringify(this.state)
        }).then(function (response) {
            console.log(response);
            response.json().then(function (json)
            {
                that.setState({ message: !response.ok ? `status: ${response.statusText}` : json.messages.join('<br>') });    
            });
        });

        event.preventDefault();
    }

    render() {
        return (
            <div>
                <form onSubmit={this.handleSubmit}>
                    <h1> Заполните анкету:<br /></h1>
                    <h2> Введите фамилию, имя:<br /></h2>
                    <input type='text' name='name' value={this.state.name} onChange={this.handleChange} /><br />
                    <h3> Укажите пол:<br /></h3>
                    <input type="RADIO" checked={this.state.isMale} name="isMale" value="true" onChange={this.handleBoolChange} /> Мужской<br />
                    <input type="RADIO" checked={!this.state.isMale} name="isMale" value="false" onChange={this.handleBoolChange}/> Женский
            <h3>  Укажите образование:<br /></h3>
                    <select name="education"
                        value={this.state.education}
                        onChange={this.handleChange}>
                        <option value="High">Высшее</option>
                        <option value="Partly">Незаконченное высшее</option>
                        <option value="Middle">Среднее полное</option>
                    </select>
                    <h3>  Наличие авто:<br /></h3>
                    <input type="CHECKBOX" name="hasCar" isSelected={this.state.hasCar} value={this.state.hasCar ? "true" : "false"} onCheckboxChange={this.handleBoolChange} />

                    <div><p>
                        <input type="submit" value="Отправить" />
                        <input type="reset" value="Сброс" /> <br />
                    </p></div>
                </form>
                <div>
                    {this.state.message}
                </div>

            </div>
        );
    }
}

export default Home;
