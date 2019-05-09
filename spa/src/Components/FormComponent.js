import { Form, FormGroup, FormControl, ControlLabel, HelpBlock, Schema } from 'rsuite';
import { Checkbox, CheckboxGroup, Radio, RadioGroup, CheckPicker, Slider, Button, Alert } from 'rsuite';
import React from 'react';
import ReactDOM from 'react-dom';
import axios from 'axios';

const { ArrayType, StringType, NumberType } = Schema.Types;
const model = Schema.Model({
  phones: ArrayType()
    .minLength(1, 'Пожалуйста, выберите как минимум 1 вариант.')
    .isRequired('Необходимо выбрать.'),
  gender: StringType()
    .isRequired('Необходимо выбрать.')
});

class CustomField extends React.PureComponent {
  render() {
    const { name, message, label, accepter, error, ...props } = this.props;
    return (
      <FormGroup className={error ? 'has-error' : ''}>
        <ControlLabel>{label} </ControlLabel>
        <FormControl
          name={name}
          accepter={accepter}
          errorMessage={error}
          {...props}
        />
        <HelpBlock>{message}</HelpBlock>
      </FormGroup>
    );
  }
}


export default class FormComponent extends React.Component {
  constructor(props) {
    super(props);
    const formValue = {
    	gender: '',
      phones: [],
    };
    this.state = {
      formValue,
      formError: {}
    };
  }
  handleSubmit = () => {
    const { formValue } = this.state;
    if (!this.form.check()) {
    	Alert.error('Ошибка')
      return;
    }
    axios.post('/api/survey', {
    	пол: formValue.gender,
    	телефоны: formValue.phones
    }).then(resp => {
    	console.log(resp.data);
	    Alert.success('Успешно');
    })
  }
  render() {
    const { formError, formValue } = this.state;

    return (
      <div>
        <Form
          ref={ref => (this.form = ref)}
          onChange={formValue => {
            console.log(formValue);
            this.setState({ formValue });
          }}
          onCheck={formError => {
            console.log(formError, 'formError');
            this.setState({ formError });
          }}
          formValue={formValue}
          model={model}
        >

          <CustomField
            name="gender"
            label="Q1. Укажите ваш пол"
            accepter={RadioGroup}
            error={formError.gender}
          >
            <Radio value={'Мужской'}>Мужской</Radio>
            <Radio value={'Женский'}>Женский</Radio>
          </CustomField>

          <CustomField
            name="phones"
            label="Q2. Марка вашего телефона"
            accepter={CheckboxGroup}
            error={formError.phones}
            inline
          >
            <Checkbox value={'Xiaomi'}>Xiaomi</Checkbox>
            <Checkbox value={'Samsung'}>Samsung</Checkbox>
            <Checkbox value={'Apple'}>Apple</Checkbox>
            <Checkbox value={'Nokia'}>Nokia</Checkbox>
            <Checkbox value={'Other'}>Другое</Checkbox>
          </CustomField>

          <FormGroup>
            <Button appearance="primary" onClick={this.handleSubmit}>
              Ответить
            </Button>
          </FormGroup>
        </Form>
      </div>
    );
  }
}
