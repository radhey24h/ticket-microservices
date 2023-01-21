import { useEffect } from 'react';
import logger from './helper/logger';
import React from 'react'

export default function MyComponent() {

    useEffect(() => {
        logger.info('MyComponent has mounted');
      }, []);

  return (
    <div>MyComponent</div>
  )
}
