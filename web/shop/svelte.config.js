import adapter from '@sveltejs/adapter-auto';
import preprocess from 'svelte-preprocess';

/** @type {import('@sveltejs/kit').Config} */
const config = {
	// Consult https://github.com/sveltejs/svelte-preprocess
	// for more information about preprocessors
	preprocess: preprocess([
	preprocess({
      		postcss: true,
    		}),
	]),

	kit: {
	adapter:
	    adapter({
            	pages: 'build',
		assets: 'build',
		fallback: '404.html',
		precompress: false,
		spec: '.do/spec.yaml',
		name: ''
	    })
	}
};

export default config;
