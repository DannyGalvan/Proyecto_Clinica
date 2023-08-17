import { Form } from "react-bootstrap";

export const InputForm = (props) => {
  const { label, name, type, placeholder, id, value, onBlur, onChange, error } =
    props;
  return (
    <Form.Group className="mb-3" controlId={id}>
      <Form.Label className="fw-bold">{label}</Form.Label>
      <Form.Control
        name={name}
        type={type}
        placeholder={placeholder}
        value={value}
        onBlur={onBlur}
        onChange={onChange}
        onKeyUp={onChange}
        required
        autoFocus
      />
      {error && <Form.Text className="text-danger fw-bold">{error}</Form.Text>}
    </Form.Group>
  );
};
