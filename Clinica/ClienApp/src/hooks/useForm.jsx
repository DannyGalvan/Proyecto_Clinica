import { useEffect, useState } from "react";

export const useForm = (initialForm, validateForm, petition) => {
  const [form, setForm] = useState(initialForm);
  const [errors, setErrors] = useState({});
  const [loading, setLoading] = useState(false);
  const [response, setResponse] = useState(null);

  useEffect(() => {
    setForm(initialForm);
  }, [initialForm]);

  const handleError = (data) => {
    try {
      const err = {};

      data.forEach((x) => {
        const key = x.propertyName.toLowerCase();
        err[key] = x.errorMessage;
      });

      setErrors(err);
    } catch (error) {
      setErrors({});
    }
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setForm({
      ...form,
      [name]: value,
    });
    setErrors(validateForm(form));
  };

  const handleBlur = (e) => {
    handleChange(e);
    setErrors(validateForm(form));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setResponse("");
    setErrors(validateForm(form));
    setLoading(true);
    if (Object.keys(errors).length === 0) {
      try {
        const response = await petition(form);
        if (!response.exito) {
          handleError(response.data ?? []);
          setResponse(response);
        } else {
          setForm(initialForm);
          setResponse(response);
        }
      } catch (error) {
        console.log(error);
      }
    } else {
      setResponse("");
    }
    setLoading(false);
  };

  return {
    form,
    errors,
    loading,
    response,
    handleBlur,
    handleChange,
    handleSubmit,
    handleError,
  };
};
