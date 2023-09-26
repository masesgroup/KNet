# Contributing to KNet

First off, thanks for taking the time to contribute!

The following is a set of guidelines for contributing to KNet, which are hosted in the [MASES Group Organization](https://github.com/masesgroup) on GitHub. Feel free to propose changes to this document in a pull request. We are trying to have a common idea between all partecipant.

## Code of Conduct

This project and everyone participating in it is governed by the [KNet Code of Conduct](CODE_OF_CONDUCT.md). By participating, you are expected to uphold this code. Please report unacceptable behavior to [coc_reporting@masesgroup.com](mailto:coc_reporting@masesgroup.com).

# Project organization

The project is organized in this folder structure:

* **docs** (website)
* **src**
	* **config**: contains the configuration files copied from the oficial Apache Kafka delivery
	* **documentation**: contains the configuration files to generate API documentation and web-site
	* **java**
		* **knet**: contains the JVM side implementation of some classes managed from .NET side; it is structured as a complete Maven project
	* **net**
		* **KNet**: The folder containing the source and project of the Apache Kafka files ported on .NET
		* **KNetCLI**: The folder containing the source and project of the CLI for Apache Kafka
		* **templates**: The folder containing the source and project to generate the NuGet template package
* **tests**
	* **KNetTest**: The folder containing the source and project of the KNet test for Producer/Consumer APIs
	* **KNetTestAdmin**: The folder containing the source and project of the KNet test for Admin APIs
	* **KNetTest**: The folder containing the source and project of the KNet test for Streams APIs

# How Can I Contribute?

## Work on the project

An user who wants to help us can do what is described in the following chapters. 

## Development improvements

If you are a developer and want to contribute you are welcome.

## Suggesting Enhancements

This section guides you through submitting an enhancement suggestion for KNet, including completely new features and minor improvements to existing functionality. Following these guidelines helps maintainers and the community understand your suggestion and find related suggestions.

Before creating enhancement suggestions, please check this list as you might find out that you don't need to create one. When you are creating an enhancement suggestion, please include as many details as possible. Fill in [the template](PULL_REQUEST_TEMPLATE.md), including the steps that you imagine you would take if the feature you're requesting existed.

### How Do I Submit A (Good) Enhancement Suggestion?

Enhancement suggestions are tracked as GitHub issues. Create an issue on that repository and provide the following information:

* Use a clear and descriptive title for the issue to identify the suggestion.
* Provide a step-by-step description of the suggested enhancement in as many details as possible.
* Provide specific examples to demonstrate the steps. Include copy/pasteable snippets which you use in those examples, as Markdown code blocks.
* Describe the current behavior and explain which behavior you expected to see instead and why.
* Include screenshots and animated GIFs which help you demonstrate the steps or point out the part of KNet which the suggestion is related to. 
* Explain why this enhancement would be useful to most KNet users.
* Specify which version of KNet you're using.
* Specify the name and version of the OS you're using.

## Reporting Bugs

This section guides you through submitting a bug report for KNet. Following these guidelines helps maintainers and the community understand your report, reproduce the behavior, and find related reports.

Before creating bug reports, please check this list as you might find out that you don't need to create one. When you are creating a bug report, please include as many details as possible. 

> Note: If you find a Closed issue that seems like it is the same thing that you're experiencing, open a new issue and include a link to the original issue in the body of your new one.

### How Do I Submit A (Good) Bug Report?

Bugs are tracked as [GitHub issues](https://guides.github.com/features/issues/). Create an issue on that repository and provide the following information by filling in [the template](PULL_REQUEST_TEMPLATE.md).

Explain the problem and include additional details to help maintainers reproduce the problem:

* Use a clear and descriptive title for the issue to identify the problem.
* Describe the exact steps which reproduce the problem in as many details as possible. For example, start by explaining how you started KNet, e.g. which command exactly you used in the terminal, or how you started KNet otherwise. When listing steps, don't just say what you did, but explain how you did it. For example, if you moved the cursor to the end of a line, explain if you used the mouse, or a keyboard shortcut or an KNet command, and if so which one?
* Provide specific examples to demonstrate the steps. Include links to files or GitHub projects, or copy/pasteable snippets, which you use in those examples. If you're providing snippets in the issue, use Markdown code blocks.
* Describe the behavior you observed after following the steps and point out what exactly is the problem with that behavior.
* Explain which behavior you expected to see instead and why.
* Include screenshots and animated GIFs which show you following the described steps and clearly demonstrate the problem. If you use the keyboard while following the steps, record the GIF with the Keybinding Resolver shown.
* If you're reporting that KNet crashed, include a crash report with a stack trace from the operating system. On macOS, the crash report will be available in Console.app under "Diagnostic and usage information" > "User diagnostic reports". Include the crash report in the issue in a code block, a file attachment, or put it in a gist and provide link to that gist.
* If the problem is related to performance or memory, include a CPU profile capture with your report.
* If the problem wasn't triggered by a specific action, describe what you were doing before the problem happened and share more information using the guidelines below.

Provide more context by answering these questions:

* Can you reproduce the problem in safe mode?
* Did the problem start happening recently (e.g. after updating to a new version of KNet) or was this always a problem?
* If the problem started happening recently, can you reproduce the problem in an older version of KNet? What's the most recent version in which the problem doesn't happen? You can download older versions of KNet from the releases page.
* Can you reliably reproduce the issue? If not, provide details about how often the problem happens and under which conditions it normally happens.
* If the problem is related to working with files (e.g. opening and editing files), does the problem happen for all files and projects or only some? Does the problem happen only when working with local or remote files (e.g. on network drives), with files of a specific type (e.g. only JavaScript or Python files), with large files or files with very long lines, or with files in a specific encoding? Is there anything else special about the files you are using?

Include details about your configuration and environment:

* Which version of KNet are you using? 
* What's the name and version of the OS you're using?
* Are you running KNet in a virtual machine? If so, which VM software are you using and which operating systems and versions are used for the host and the guest?
* Are you using KNet with multiple monitors? If so, can you reproduce the problem when you use a single monitor?
* Which keyboard layout are you using? Are you using a US layout or some other layout?

