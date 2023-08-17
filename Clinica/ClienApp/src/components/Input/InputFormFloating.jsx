import { Col, FloatingLabel, Form } from "react-bootstrap";

export const InputFormFloating = (props) => {
  const {
    label,
    type,
    placeholder,
    name,
    onBlur,
    onChange,
    value,
    error,
    id,
    reference,
    className,
    autocomplete,
  } = props;
  const complete = autocomplete ?? "true";
  return (
    <Col className={className ?? "mb-3"}>
      <FloatingLabel controlId={id} label={label}>
        <Form.Control
          type={type}
          placeholder={placeholder}
          name={name}
          onBlur={onBlur}
          onChange={onChange}
          onKeyUp={onChange}
          value={value}
          ref={reference}
          autoComplete={complete}
          required
        />
      </FloatingLabel>
      <Form.Text className="text-danger fw-bold">{error}</Form.Text>
    </Col>
  );
};
