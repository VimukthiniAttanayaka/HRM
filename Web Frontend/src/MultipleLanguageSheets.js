import { Translation } from 'react-i18next'

export function getLabelText(texttoconvert,templatetype) {
   return (
    <Translation ns={[templatetype]}>
    {
      (t) => <strong>{t(texttoconvert, { ns: templatetype })}</strong>
    }
    
    </Translation>
  );
}
